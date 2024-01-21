using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CapybaraTranslateAddin.ApiClient;
using CapybaraTranslateAddin.Configuration;
using CapybaraTranslateAddin.UI;
using DiffMatchPatch;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Tools.Ribbon;
using Application = Microsoft.Office.Interop.Excel.Application;
using Diff = CapybaraTranslateAddin.Utilities.Diff;

namespace CapybaraTranslateAddin
{
    public partial class MainRibbon
    {
        private AddinConfiguration _addinConfiguration;


        public Application Application => Globals.ThisAddIn.Application;

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
            _addinConfiguration = LoadAddinConfiguration();
            InitializeRibbonControls();
        }

        private AddinConfiguration LoadAddinConfiguration()
        {
            var configJson = AppUtils.GetAddinConfigJsonPath();
            return AddinConfiguration.LoadFrom(configJson);
        }

        private void InitializeRibbonControls()
        {
            var engines = new[]
            {
                new
                {
                    Id = DeepLClient.EngineCode,
                    Label = DeepLClient.EngineName,
                    IsSelected = _addinConfiguration.LastSelectedEngine == DeepLClient.EngineCode
                },
                new
                {
                    Id = OpenAiClient.EngineCodeGpt4,
                    Label = OpenAiClient.EngineNameGpt4,
                    IsSelected = _addinConfiguration.LastSelectedEngine == OpenAiClient.EngineCodeGpt4
                },
                new
                {
                    Id = GoogleClient.EngineCode,
                    Label = GoogleClient.EngineName,
                    IsSelected = _addinConfiguration.LastSelectedEngine == GoogleClient.EngineCode
                }
            };
            foreach (var engine in engines)
            {
                var item = Factory.CreateRibbonDropDownItem();
                item.Tag = engine.Id;
                item.Label = engine.Label;
                engineDropDown.Items.Add(item);
            }

            var idx = engines.ToList().FindIndex(x => x.IsSelected);
            idx = idx >= 0 ? idx : 0;
            engineDropDown.SelectedItemIndex = idx;
            engineDropDown_SelectionChanged(engineDropDown, null);
        }

        private void InitializeLanguageDropdown(RibbonDropDown dropDown, List<Language> languages,
            string defaultLanguageCode)
        {
            dropDown.Items.Clear();
            foreach (var language in languages)
            {
                var item = Factory.CreateRibbonDropDownItem();
                item.Tag = language.Value;
                item.Label = language.Label;
                dropDown.Items.Add(item);
            }

            var idx = languages.FindIndex(x => x.Value == defaultLanguageCode);
            idx = idx >= 0 ? idx : 0;
            dropDown.SelectedItemIndex = idx;
        }


        private void openConfigButton_Click(object sender, RibbonControlEventArgs e)
        {
            var dialog = new ConfigurationForm(_addinConfiguration);
            dialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
        }

        private void MainRibbon_Close(object sender, EventArgs e)
        {
            var engineCode = engineDropDown.SelectedItem.Tag.ToString();
            _addinConfiguration.LastSelectedEngine = engineCode;
            if (engineCode == DeepLClient.EngineCode)
            {
                _addinConfiguration.DeepL.LastSelectedSourceLanguage = fromLangDropDown.SelectedItem.Tag.ToString();
                _addinConfiguration.DeepL.LastSelectedTargetLanguage = toLangDropDown.SelectedItem.Tag.ToString();
            }
            else if (engineCode == OpenAiClient.EngineCodeGpt4)
            {
                _addinConfiguration.OpenAi.LastSelectedSourceLanguage = fromLangDropDown.SelectedItem.Tag.ToString();
                _addinConfiguration.OpenAi.LastSelectedTargetLanguage = toLangDropDown.SelectedItem.Tag.ToString();
            }
            else
            {
                _addinConfiguration.Google.LastSelectedSourceLanguage = fromLangDropDown.SelectedItem.Tag.ToString();
                _addinConfiguration.Google.LastSelectedTargetLanguage = toLangDropDown.SelectedItem.Tag.ToString();
            }

            _addinConfiguration.SaveTo(AppUtils.GetAddinConfigJsonPath());
        }

        private void engineDropDown_SelectionChanged(object sender, RibbonControlEventArgs e)
        {
            var dropDown = sender as RibbonDropDown;
            if (dropDown == null) return;

            var engineCode = dropDown.SelectedItem.Tag.ToString();
            if (engineCode == DeepLClient.EngineCode)
            {
                InitializeLanguageDropdown(fromLangDropDown, DeepLClient.SupportedSourceLanguages,
                    _addinConfiguration.DeepL.LastSelectedSourceLanguage ?? DeepLClient.DefaultSourceLanguage);
                InitializeLanguageDropdown(toLangDropDown, DeepLClient.SupportedTargetLanguages,
                    _addinConfiguration.DeepL.LastSelectedTargetLanguage ?? DeepLClient.DefaultTargetLanguage);
            }
            else if (engineCode == OpenAiClient.EngineCodeGpt4)
            {
                InitializeLanguageDropdown(fromLangDropDown, OpenAiClient.SupportedSourceLanguages,
                    _addinConfiguration.OpenAi.LastSelectedSourceLanguage ?? OpenAiClient.DefaultSourceLanguage);
                InitializeLanguageDropdown(toLangDropDown, OpenAiClient.SupportedTargetLanguages,
                    _addinConfiguration.OpenAi.LastSelectedTargetLanguage ?? OpenAiClient.DefaultTargetLanguage);
            }
            else
            {
                InitializeLanguageDropdown(fromLangDropDown, GoogleClient.SupportedSourceLanguages,
                    _addinConfiguration.Google.LastSelectedSourceLanguage ?? GoogleClient.DefaultSourceLanguage);
                InitializeLanguageDropdown(toLangDropDown, GoogleClient.SupportedTargetLanguages,
                    _addinConfiguration.Google.LastSelectedTargetLanguage ?? GoogleClient.DefaultTargetLanguage);
            }
        }


        private async void TranslateSelectedCells(ITranslationClient client)
        {
            var oldStatusBar = Application.DisplayStatusBar;
            var progressMsg = "Translating selected cells...";
            Application.DisplayStatusBar = true;
            Application.StatusBar = progressMsg;
            ProgressDialog progressDialog = null;
            try
            {
                translateButton.Enabled = false;
                var from = fromLangDropDown.SelectedItem.Tag.ToString();
                var to = toLangDropDown.SelectedItem.Tag.ToString();
                Range selection = Application.Selection;
                progressDialog = new ProgressDialog(progressMsg, 1, selection.Count);
                progressDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
                var progress = 0;
                foreach (var cells in selection.ToList().Chunk(3))
                {
                    var tasks = cells.Select(cell =>
                    {
                        return Task.Run(async () =>
                        {
                            string text = cell.Text;
                            if (!string.IsNullOrWhiteSpace(text))
                            {
                                var translation = await client.TranslateAsync(text, from, to);
                                cell.Value = translation;
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
                translateButton.Enabled = true;
                Application.DisplayStatusBar = oldStatusBar;
                Application.StatusBar = false;
                progressDialog?.Close();
            }
        }

        private void translateButton_Click(object sender, RibbonControlEventArgs e)
        {
            try
            {
                var engineCode = engineDropDown.SelectedItem.Tag.ToString();
                if (engineCode == DeepLClient.EngineCode)
                {
                    var client = new DeepLClient(new DeepLClientOptions
                    {
                        ApiKey = _addinConfiguration.DeepL.ApiKey
                    });
                    TranslateSelectedCells(client);
                }
                else if (engineCode == GoogleClient.EngineCode)
                {
                    var client = new GoogleClient(new GoogleClientOptions
                    {
                        Credentials = _addinConfiguration.Google.Credentials
                    });
                    TranslateSelectedCells(client);
                }
                else
                {
                    var client = new OpenAiClient(new OpenAiClientOptions
                    {
                        ApiKey = _addinConfiguration.OpenAi.ApiKey
                    });
                    TranslateSelectedCells(client);
                }
            }
            catch (Exception ex)
            {
                var errorMessageDialog = new ErrorMessageDialog(ex);
                errorMessageDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
            }
        }

        private void swapButton_Click(object sender, RibbonControlEventArgs e)
        {
            var fromLang = fromLangDropDown.SelectedItem.Tag.ToString();
            var toLang = toLangDropDown.SelectedItem.Tag.ToString();
            var engineCode = engineDropDown.SelectedItem.Tag.ToString();
            if (engineCode == DeepLClient.EngineCode)
            {
                fromLang = DeepLClient.NormalizeDialect(fromLang);
                toLang = DeepLClient.NormalizeDialect(toLang);
            }

            var newFromIdx = fromLangDropDown.Items.Select(x => x.Tag.ToString()).ToList()
                .FindIndex(tag => tag == toLang);
            if (newFromIdx >= 0) fromLangDropDown.SelectedItemIndex = newFromIdx;

            var newToIdx = toLangDropDown.Items.Select(x => x.Tag.ToString()).ToList()
                .FindIndex(tag => tag == fromLang);
            if (newToIdx >= 0) toLangDropDown.SelectedItemIndex = newToIdx;
        }

        private void openTtsPaneButton_Click(object sender, RibbonControlEventArgs e)
        {
            var taskPane =
                TaskPaneManager.GetOrCreate("Text to Speech", "tts", () => new TtsTaskPaneControl(_addinConfiguration));

            taskPane.Visible = true;
        }

        private void ShowProductInfoButton_Click(object sender, RibbonControlEventArgs e)
        {
            using (var dialog = new ProductInfoDialog())
            {
                dialog.ShowDialog(new ArbitraryWindow(new IntPtr(Application.Hwnd)));

            }
        }

        private void openSttPaneButton_Click(object sender, RibbonControlEventArgs e)
        {
            var taskPane =
                TaskPaneManager.GetOrCreate("Speech to Text", "stt", () => new SttTaskPaneControl(_addinConfiguration));

            taskPane.Visible = true;
        }

        private async void DiffButton_Click(object sender, RibbonControlEventArgs e)
        {
            var oldStatusBar = Application.DisplayStatusBar;
            var progressMsg = "Running text comparison on selected cells...";
            Application.DisplayStatusBar = true;
            Application.StatusBar = progressMsg;
            ProgressDialog progressDialog = null;

            try
            {
                Range selection = Application.Selection;
                progressDialog = new ProgressDialog(progressMsg, 1, selection.Count);
                progressDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
                await Diff.RunOnSelectedCells((progress) => progressDialog.ReportProgress(progress));
            }
            catch (Exception ex)
            {
                var errorMessageDialog = new ErrorMessageDialog(ex);
                errorMessageDialog.Show(new ArbitraryWindow(new IntPtr(Application.Hwnd)));
            }
            finally
            {
                Application.DisplayStatusBar = oldStatusBar;
                Application.StatusBar = false;
                progressDialog?.Close();
            }
        }
    }
}