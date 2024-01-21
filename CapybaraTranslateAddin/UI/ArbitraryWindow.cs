using System;
using System.Windows.Forms;

namespace CapybaraTranslateAddin.UI
{
    public class ArbitraryWindow : IWin32Window
    {
        public ArbitraryWindow(IntPtr handle) { Handle = handle; }
        public IntPtr Handle { get; }
    }
}