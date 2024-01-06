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
            this.preferencesGroup = this.Factory.CreateRibbonGroup();
            this.openConfigButton = this.Factory.CreateRibbonButton();
            this.translationGroup = this.Factory.CreateRibbonGroup();
            this.engineDropDown = this.Factory.CreateRibbonDropDown();
            this.fromLangDropDown = this.Factory.CreateRibbonDropDown();
            this.toLangDropDown = this.Factory.CreateRibbonDropDown();
            this.swapButton = this.Factory.CreateRibbonButton();
            this.translateButton = this.Factory.CreateRibbonButton();
            this.ttsGroup = this.Factory.CreateRibbonGroup();
            this.openTtsPaneButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.preferencesGroup.SuspendLayout();
            this.translationGroup.SuspendLayout();
            this.ttsGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.preferencesGroup);
            this.tab1.Groups.Add(this.translationGroup);
            this.tab1.Groups.Add(this.ttsGroup);
            this.tab1.Label = "Capybara Translate";
            this.tab1.Name = "tab1";
            // 
            // preferencesGroup
            // 
            this.preferencesGroup.Items.Add(this.openConfigButton);
            this.preferencesGroup.Label = "Preferences";
            this.preferencesGroup.Name = "preferencesGroup";
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
            // translationGroup
            // 
            this.translationGroup.Items.Add(this.engineDropDown);
            this.translationGroup.Items.Add(this.fromLangDropDown);
            this.translationGroup.Items.Add(this.toLangDropDown);
            this.translationGroup.Items.Add(this.swapButton);
            this.translationGroup.Items.Add(this.translateButton);
            this.translationGroup.Label = "Translation";
            this.translationGroup.Name = "translationGroup";
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
            // ttsGroup
            // 
            this.ttsGroup.Items.Add(this.openTtsPaneButton);
            this.ttsGroup.Label = "Text to Speech";
            this.ttsGroup.Name = "ttsGroup";
            // 
            // openTtsPaneButton
            // 
            this.openTtsPaneButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.openTtsPaneButton.Label = "Show TTS Pane";
            this.openTtsPaneButton.Name = "openTtsPaneButton";
            this.openTtsPaneButton.OfficeImageId = "SoundInsertFromFile";
            this.openTtsPaneButton.ShowImage = true;
            this.openTtsPaneButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.openTtsPaneButton_Click);
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
            this.preferencesGroup.ResumeLayout(false);
            this.preferencesGroup.PerformLayout();
            this.translationGroup.ResumeLayout(false);
            this.translationGroup.PerformLayout();
            this.ttsGroup.ResumeLayout(false);
            this.ttsGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup preferencesGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openConfigButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup translationGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown engineDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown fromLangDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonDropDown toLangDropDown;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton translateButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup ttsGroup;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton swapButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton openTtsPaneButton;
    }

    partial class ThisRibbonCollection
    {
        internal MainRibbon MainRibbon
        {
            get { return this.GetRibbon<MainRibbon>(); }
        }
    }
}
