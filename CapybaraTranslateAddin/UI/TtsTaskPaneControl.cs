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
    public partial class TtsTaskPaneControl : UserControl
    {
        private readonly AddinConfiguration _addinConfiguration;

        public TtsTaskPaneControl(AddinConfiguration addinConfiguration)
        {
            InitializeComponent();
            _addinConfiguration = addinConfiguration;
            InitializeControls();
            Disposed += TtsTaskPaneControl_Disposed;
        }

        public Application Application => Globals.ThisAddIn.Application;

        private void TtsTaskPaneControl_Disposed(object sender, EventArgs e)
        {
            _addinConfiguration.Google.LastSelectedSoundFolder = saveToTextBox.Text;
            _addinConfiguration.Google.LastSelectedVoiceName = voiceComboBox.Text;
            _addinConfiguration.Google.LastSelectedFilenameColumn = cellValueForFilenameTextBox.Text;
        }

        private void InitializeControls()
        {
            foreach (var voiceName in GoogleClient.SupportedTtsVoiceNames) voiceComboBox.Items.Add(voiceName);

            var defaultVoice = string.IsNullOrWhiteSpace(_addinConfiguration.Google.LastSelectedVoiceName)
                ? GoogleClient.DefaultTtsVoiceName
                : _addinConfiguration.Google.LastSelectedVoiceName;
            var idx = GoogleClient.SupportedTtsVoiceNames.FindIndex(x =>
                x == defaultVoice);
            idx = idx >= 0 ? idx : 0;
            voiceComboBox.SelectedIndex = idx;

            if (string.IsNullOrWhiteSpace(saveToTextBox.Text))
            {
                var defaultFolder = string.IsNullOrWhiteSpace(_addinConfiguration.Google.LastSelectedSoundFolder)
                    ? AppUtils.GetDefaultSoundFolder()
                    : _addinConfiguration.Google.LastSelectedSoundFolder;
                saveToTextBox.Text = defaultFolder;
            }

            if (string.IsNullOrWhiteSpace(cellValueForFilenameTextBox.Text))
            {
                var defaultFilenameColumn =
                    string.IsNullOrWhiteSpace(_addinConfiguration.Google.LastSelectedFilenameColumn)
                        ? ""
                        : _addinConfiguration.Google.LastSelectedFilenameColumn;
                cellValueForFilenameTextBox.Text = defaultFilenameColumn;
            }
        }

        private void cellValueForFilenameTextBox_MouseEnter(object sender, EventArgs e)
        {
            cellValueForFilenameToolTip.Show(@"Type a column name, e.g., ""A"" or ""B"".", cellValueForFilenameTextBox);
        }

        private void cellValueForFilenameTextBox_MouseLeave(object sender, EventArgs e)
        {
            cellValueForFilenameToolTip.Hide(cellValueForFilenameTextBox);
        }

        private async void RunTextToSpeechOnSelectedCells(ITextToSpeechClient client)
        {
            var oldStatusBar = Application.DisplayStatusBar;
            var progressMsg = "Running text-to-speech on selected cells...";

            Application.DisplayStatusBar = true;
            Application.StatusBar = progressMsg;
            ProgressDialog progressDialog = null;

            try
            {
                runTtsButton.Enabled = false;
                var voiceName = voiceComboBox.Text;
                var filenameColumn = cellValueForFilenameTextBox.Text.Trim();
                Range selection = Application.Selection;
                Worksheet activeSheet = Application.ActiveSheet;
                var selectedCellCount = selection.Count;
                var filenameLength = selectedCellCount.ToString().Length + ".mp3".Length;
                var destFolder = saveToTextBox.Text.Trim();
                var progress = 0;
                progressDialog = new ProgressDialog(progressMsg, 1, selectedCellCount);
                progressDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));

                foreach (var cells in selection.ToList().Select((cell, idx) => new { No = idx + 1, Cell = cell })
                             .Chunk(5))
                {
                    var tasks = cells.Select(numberedCell =>
                    {
                        return Task.Run(async () =>
                        {
                            var cell = numberedCell.Cell;
                            var no = numberedCell.No;

                            string text = cell.Text;
                            var row = cell.Row;
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                string filename;
                                if (!string.IsNullOrWhiteSpace(filenameColumn))
                                    filename = activeSheet.Range[$"{filenameColumn}{row}"].Text;
                                else
                                    filename = $"{no}.mp3".PadLeft(filenameLength, '0');

                                var destination = Path.Combine(destFolder, filename);

                                await client.TextToSpeechAsync(text, voiceName, destination);
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
                runTtsButton.Enabled = true;
                Application.DisplayStatusBar = oldStatusBar;
                Application.StatusBar = false;
                progressDialog?.Close();
            }
        }

        private void runTtsButton_Click(object sender, EventArgs e)
        {
            try
            {
                var client = new GoogleClient(new GoogleClientOptions
                {
                    Credentials = _addinConfiguration.Google.Credentials
                });
                RunTextToSpeechOnSelectedCells(client);
            }
            catch (Exception ex)
            {
                var errorMessageDialog = new ErrorMessageDialog(ex);
                errorMessageDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
            }
        }
    }
}