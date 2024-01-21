using System;
using System.Windows.Forms;

namespace CapybaraTranslateAddin.UI
{
    public partial class ErrorMessageDialog : Form
    {
        public ErrorMessageDialog(Exception exception)
        {
            InitializeComponent();
            MessageTextBox.Text = exception.ToString();
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        protected override bool ShowWithoutActivation
        {
            get => true;
        }

    }
}