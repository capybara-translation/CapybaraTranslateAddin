using System;

namespace CapybaraTranslateAddin
{
    public partial class ThisAddIn
    {

        private void ThisAddIn_Startup(object sender, EventArgs e)
        {
        }



        private void ThisAddIn_Shutdown(object sender, EventArgs e)
        {
        }

        #region VSTO で生成されたコード

        /// <summary>
        ///     デザイナーのサポートに必要なメソッドです。
        ///     コード エディターで変更しないでください。
        /// </summary>
        private void InternalStartup()
        {
            Startup += ThisAddIn_Startup;
            Shutdown += ThisAddIn_Shutdown;
        }

        #endregion
    }
}