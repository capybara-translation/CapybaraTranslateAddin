using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapybaraTranslateAddin.ApiClient;
using CapybaraTranslateAddin.Configuration;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;


namespace CapybaraTranslateAddin.UI
{
    public partial class SttTaskPaneControl : UserControl
    {
        public Application Application => Globals.ThisAddIn.Application;

        private readonly AddinConfiguration _addinConfiguration;
        public SttTaskPaneControl(AddinConfiguration addinConfiguration)
        {
            InitializeComponent();
            _addinConfiguration = addinConfiguration;
            InitializeControls();
            Disposed += SttTaskPaneControl_Disposed;
        }

        private void SttTaskPaneControl_Disposed(object sender, EventArgs e)
        {
            _addinConfiguration.Google.LastSelectedSpeechToTextLanguage =
                ((Language)sttLanguageComboBox.SelectedItem).Value;
        }

        private void InitializeControls()
        {

            sttLanguageComboBox.ValueMember = "Value";
            sttLanguageComboBox.DisplayMember = "Label";
            sttLanguageComboBox.DataSource = GoogleClient.SupportedSttLanguages;
            var defaultLang = string.IsNullOrWhiteSpace(_addinConfiguration.Google.LastSelectedSpeechToTextLanguage)
                ? GoogleClient.DefaultSttLanguage
                : _addinConfiguration.Google.LastSelectedSpeechToTextLanguage;
            var idx = GoogleClient.SupportedSttLanguages.FindIndex(x => x.Value == defaultLang);
            idx = idx >= 0 ? idx : 0;
            sttLanguageComboBox.SelectedIndex = idx;
        }

        private async void RunSpeechToTextOnSelectedCells(ISpeechToTextClient client)
        {
            var oldStatusBar = Application.DisplayStatusBar;
            var progressMsg = "Running speech-to-text on selected cells...";

            Application.DisplayStatusBar = true;
            Application.StatusBar = progressMsg;
            ProgressDialog progressDialog = null;

            try
            {
                runSttButton.Enabled = false;
                var languageCode = ((Language)sttLanguageComboBox.SelectedItem).Value;
                Range selection = Application.Selection;
                Worksheet activeSheet = Application.ActiveSheet;
                var selectedCellCount = selection.Count;
                var progress = 0;
                progressDialog = new ProgressDialog(progressMsg, 1, selectedCellCount);
                progressDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));

                foreach (var cells in selection.ToList().Chunk(5))
                {
                    var tasks = cells.Select(cell =>
                    {
                        return Task.Run(async () =>
                        {

                            string mp3File = cell.Text;
                            var row = cell.Row;
                            if (!string.IsNullOrWhiteSpace(mp3File) && File.Exists(mp3File))
                            {

                                cell.Value = await client.SpeechToTextAsync(mp3File, languageCode);
                            }

                            progressDialog.ReportProgress(++progress);
                        });
                    });
                    await Task.WhenAll(tasks);
                }
            }
            catch (Exception ex)
            {
                var errorMessageDialog = new ErrorMessageDialog(ex);
                errorMessageDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
            }
            finally
            {
                runSttButton.Enabled = true;
                Application.DisplayStatusBar = oldStatusBar;
                Application.StatusBar = false;
                progressDialog?.Close();
            }
        }
        private void runSttButton_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new GoogleClient(new GoogleClientOptions
                {
                    Credentials = _addinConfiguration.Google.Credentials
                });
                RunSpeechToTextOnSelectedCells(client);
            }
            catch (Exception ex)
            {
                var errorMessageDialog = new ErrorMessageDialog(ex);
                errorMessageDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
            }
        }
    }
}
