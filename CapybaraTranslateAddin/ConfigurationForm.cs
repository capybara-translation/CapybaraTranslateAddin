using System;
using System.IO;
using System.Windows.Forms;
using CapybaraTranslateAddin.Configuration;

namespace CapybaraTranslateAddin
{
    public partial class ConfigurationForm : Form
    {
        private readonly AddinConfiguration _addinConfiguration;

        public ConfigurationForm(AddinConfiguration addinConfiguration)
        {
            InitializeComponent();

            _addinConfiguration = addinConfiguration;
            DeepLApiKeyTextBox.Text = _addinConfiguration.DeepL.ApiKey;
            OpenAiApiKeyTextBox.Text = _addinConfiguration.OpenAi.ApiKey;
            GoogleCredentialsTextBox.Text = _addinConfiguration.Google.Credentials;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            _addinConfiguration.DeepL.ApiKey = DeepLApiKeyTextBox.Text;
            _addinConfiguration.OpenAi.ApiKey = OpenAiApiKeyTextBox.Text;
            _addinConfiguration.Google.Credentials = GoogleCredentialsTextBox.Text;
            Close();
        }

        private void LoadFromKeyFileButton_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog())
            {
                ofd.Filter = "Json Files|*.json";
                ofd.Title = "Select a secret key file";
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                    using (var stream = ofd.OpenFile())
                    using (var sr = new StreamReader(stream))
                    {
                        GoogleCredentialsTextBox.Text = sr.ReadToEnd();
                    }
            }
        }
    }
}