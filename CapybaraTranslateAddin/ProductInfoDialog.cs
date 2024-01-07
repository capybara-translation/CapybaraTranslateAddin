using System.Windows.Forms;

namespace CapybaraTranslateAddin
{
    public partial class ProductInfoDialog : Form
    {
        public ProductInfoDialog()
        {
            InitializeComponent();
            var addinName = AppUtils.GetAddinName();
            var version = AppUtils.GetAddinVersion();
            VersionLabel.Text = $"{addinName} (Version {version})";
        }

        private void ProductInfoDialog_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Close();
            }
        }
    }
}