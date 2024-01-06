using System;
using System.Windows.Forms;

namespace CapybaraTranslateAddin
{
    public partial class ProgressDialog : Form
    {
        private IProgress<int> _progress;
        public ProgressDialog(string title, int min, int max)
        {
            InitializeComponent();
            progressBar.Minimum = min;
            progressBar.Maximum = max;
            Text = title;
            _progress = new Progress<int>(OnProgressChanged);
        }

        public void ReportProgress(int value)
        {
            _progress.Report(value);
        }

        private void OnProgressChanged(int value)
        {
            progressBar.Value = value;
        }
    }
}
