namespace CapybaraTranslateAddin
{
    partial class MainRibbon : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public MainRibbon()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tab1 = this.Factory.CreateRibbonTab();
            this.PreferencesGroup = this.Factory.CreateRibbonGroup();
            this.TranslationGroup = this.Factory.CreateRibbonGroup();
            this.engineDropDown = this.Factory.CreateRibbonDropDown();
            this.fromLangDropDown = this.Factory.CreateRibbonDropDown();
            this.toLangDropDown = this.Factory.CreateRibbonDropDown();
            this.TtsGroup = this.Factory.CreateRibbonGroup();
            this.SttGroup = this.Factory.CreateRibbonGroup();
            this.UtilitiesGroup = this.Factory.CreateRibbonGroup();
            this.HelpGroup = this.Factory.CreateRibbonGroup();
            this.openConfigButton = this.Factory.CreateRibbonButton();
            this.swapButton = this.Factory.CreateRibbonButton();
            this.translateButton = this.Factory.CreateRibbonButton();
            this.openTtsPaneButton = this.Factory.CreateRibbonButton();
            this.openSttPaneButton = this.Factory.CreateRibbonButton();
            this.DiffButton = this.Factory.CreateRibbonButton();
            this.ShowProductInfoButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.PreferencesGroup.SuspendLayout();
            this.TranslationGroup.SuspendLayout();
            this.TtsGroup.SuspendLayout();
            this.SttGroup.SuspendLayout();
            this.UtilitiesGroup.SuspendLayout();
            this.HelpGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.PreferencesGroup);
            this.tab1.Groups.Add(this.TranslationGroup);
            this.tab1.Groups.Add(this.TtsGroup);
            this.tab1.Groups.Add(this.SttGroup);
            this.tab1.Groups.Add(this.UtilitiesGroup);
            this.tab1.Groups.Add(this.HelpGroup);
            this.tab1.Label = "Capybara Translate";
            this.tab1.Name = "tab1";
            // 
            // PreferencesGroup
            // 
            this.PreferencesGroup.Items.Add(this.openConfigButton);
            this.PreferencesGroup.Label = "Preferences";
            this.PreferencesGroup.Name = "PreferencesGroup";
            // 
            // TranslationGroup
            // 
            this.TranslationGroup.Items.Add(this.engineDropDown);
            this.TranslationGroup.Items.Add(this.fromLangDropDown);
            this.TranslationGroup.Items.Add(this.toLangDropDown);
            this.TranslationGroup.Items.Add(this.swapButton);
            this.TranslationGroup.Items.Add(this.translateButton);
            this.TranslationGroup.Label = "Translation";
            this.TranslationGroup.Name = "TranslationGroup";
            // 
            // engineDropDown
            // 
            this.engineDropDown.Label = "Engine:";
            this.engineDropDown.Name = "engineDropDown";
            this.engineDropDown.SelectionChanged += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.engineDropDown_SelectionChanged);
            // 
            // fromLangDropDown
            // 
            this.fromLangDropDown.Label = "From";
            this.fromLangDropDown.Name = "fromLangDropDown";
            this.fromLangDropDown.SizeString = "Portuguese (Brazilian)";
            // 
            // toLangDropDown
            // 
            this.toLangDropDown.Label = "To";
            this.toLangDropDown.Name = "toLangDropDown";
            this.toLangDropDown.SizeString = "Portuguese (Brazilian)";
            // 
            // TtsGroup
            // 
            this.TtsGroup.Items.Add(this.openTtsPaneButton);
            this.TtsGroup.Label = "Text to Speech";
            this.TtsGroup.Name = "TtsGroup";
            // 
            // SttGroup
            // 
            this.SttGroup.Items.Add(this.openSttPaneButton);
            this.SttGroup.Label = "Speech to Text";
            this.SttGroup.Name = "SttGroup";
            // 
            // UtilitiesGroup
            // 
            this.UtilitiesGroup.Items.Add(this.DiffButton);
            this.UtilitiesGroup.Label = "Utilities";
            this.UtilitiesGroup.Name = "UtilitiesGroup";
            // 
            // HelpGroup
            // 
            this.HelpGroup.Items.Add(this.ShowProductInfoButton);
            this.HelpGroup.Label = "Help";
            this.HelpGroup.Name = "HelpGroup";
            // 
            // openConfigButton
            // 
            this.openConfigButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openConfigButton.Label = "Settings";
            this.openConfigButton.Name = "openConfigButton";
            this.openConfigButton.OfficeImageId = "Preferences";
            this.openConfigButton.ShowImage = true;
            this.openConfigButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openConfigButton_Click);
            // 
            // swapButton
            // 
            this.swapButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.swapButton.Label = "Swap";
            this.swapButton.Name = "swapButton";
            this.swapButton.OfficeImageId = "TranslateMenu";
            this.swapButton.ShowImage = true;
            this.swapButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.swapButton_Click);
            // 
            // translateButton
            // 
            this.translateButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.translateButton.Label = "Translate";
            this.translateButton.Name = "translateButton";
            this.translateButton.OfficeImageId = "Translate";
            this.translateButton.ShowImage = true;
            this.translateButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.translateButton_Click);
            // 
            // openTtsPaneButton
            // 
            this.openTtsPaneButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openTtsPaneButton.Label = "Text to Speech";
            this.openTtsPaneButton.Name = "openTtsPaneButton";
            this.openTtsPaneButton.OfficeImageId = "SoundInsertFromFile";
            this.openTtsPaneButton.ShowImage = true;
            this.openTtsPaneButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openTtsPaneButton_Click);
            // 
            // openSttPaneButton
            // 
            this.openSttPaneButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openSttPaneButton.Label = "Speech to Text";
            this.openSttPaneButton.Name = "openSttPaneButton";
            this.openSttPaneButton.OfficeImageId = "SoundInsertFromFile";
            this.openSttPaneButton.ShowImage = true;
            this.openSttPaneButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openSttPaneButton_Click);
            // 
            // DiffButton
            // 
            this.DiffButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.DiffButton.Label = "Compare";
            this.DiffButton.Name = "DiffButton";
            this.DiffButton.OfficeImageId = "ReviewCompareTwoVersions";
            this.DiffButton.ScreenTip = "Compare cell texts";
            this.DiffButton.ShowImage = true;
            this.DiffButton.SuperTip = "Compare selected cell texts against their adjacent ones.";
            this.DiffButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DiffButton_Click);
            // 
            // ShowProductInfoButton
            // 
            this.ShowProductInfoButton.Label = "About This Addin";
            this.ShowProductInfoButton.Name = "ShowProductInfoButton";
            this.ShowProductInfoButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.ShowProductInfoButton_Click);
            // 
            // MainRibbon
            // 
            this.Name = "MainRibbon";
            this.RibbonType = "Microsoft.Excel.Workbook";
            this.Tabs.Add(this.tab1);
            this.Close += new System.EventHandler(this.MainRibbon_Close);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.MainRibbon_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.PreferencesGroup.ResumeLayout(false);
            this.PreferencesGroup.PerformLayout();
            this.TranslationGroup.ResumeLayout(false);
            this.TranslationGroup.PerformLayout();
            this.TtsGroup.ResumeLayout(false);
            this.TtsGroup.PerformLayout();
            this.SttGroup.ResumeLayout(false);
            this.SttGroup.PerformLayout();
            this.UtilitiesGroup.ResumeLayout(false);
            this.UtilitiesGroup.PerformLayout();
            this.HelpGroup.ResumeLayout(false);
            this.HelpGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup PreferencesGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openConfigButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup TranslationGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown engineDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown fromLangDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown toLangDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton translateButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup TtsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton swapButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openTtsPaneButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup HelpGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton ShowProductInfoButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openSttPaneButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup SttGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup UtilitiesGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton DiffButton;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
