using System;
using System.IO;
using System.Windows.Forms;
using CapybaraTranslateAddin.ApiClient;
using CapybaraTranslateAddin.Configuration;
using Application = Microsoft.Office.Interop.Excel.Application;

namespace CapybaraTranslateAddin
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
                var voiceName = voiceComboBox.Text;
                var selection = Application.Selection;
                var filenameColumn = cellValueForFilenameTextBox.Text.Trim();
                var activeSheet = Application.ActiveSheet;
                int selectedCellCount = selection.Count;
                var filenameLength = selectedCellCount.ToString().Length + ".mp3".Length;
                var destFolder = saveToTextBox.Text.Trim();
                var count = 0;
                var progress = 0;
                progressDialog = new ProgressDialog(progressMsg, 1, selectedCellCount);
                progressDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));

                foreach (var cell in selection)
                {
                    var text = cell.Text;
                    var row = cell.Row;
                    if (!string.IsNullOrWhiteSpace(text))
                    {
                        count++;
                        string filename;
                        if (!string.IsNullOrWhiteSpace(filenameColumn))
                            filename = activeSheet.Range[$"{filenameColumn}{row}"].Text;
                        else
                            filename = $"{count}.mp3".PadLeft(filenameLength, '0');

                        var destination = Path.Combine(destFolder, filename);

                        var isSuccess = await client.TextToSpeechAsync(text, voiceName, destination);
                    }
                    progressDialog.ReportProgress(++progress);

                }
            }
            finally
            {
                Application.DisplayStatusBar = oldStatusBar;
                Application.StatusBar = false;
                progressDialog?.Close();
            }
        }

        private void runTtsButton_Click(object sender, EventArgs e)
        {
            var client = new GoogleClient(new GoogleClientOptions
            {
                Credentials = _addinConfiguration.Google.Credentials
            });
            RunTextToSpeechOnSelectedCells(client);
        }
    }
}