namespace CapybaraTranslateAddin
{
    partial class SttTaskPaneControl
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.label1 = new System.Windows.Forms.Label();
            this.sttLanguageComboBox = new System.Windows.Forms.ComboBox();
            this.runSttButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Language:";
            // 
            // sttLanguageComboBox
            // 
            this.sttLanguageComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sttLanguageComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sttLanguageComboBox.FormattingEnabled = true;
            this.sttLanguageComboBox.Location = new System.Drawing.Point(105, 46);
            this.sttLanguageComboBox.Name = "sttLanguageComboBox";
            this.sttLanguageComboBox.Size = new System.Drawing.Size(286, 23);
            this.sttLanguageComboBox.TabIndex = 1;
            // 
            // runSttButton
            // 
            this.runSttButton.Location = new System.Drawing.Point(34, 95);
            this.runSttButton.Name = "runSttButton";
            this.runSttButton.Size = new System.Drawing.Size(357, 23);
            this.runSttButton.TabIndex = 2;
            this.runSttButton.Text = "Run";
            this.runSttButton.UseVisualStyleBackColor = true;
            this.runSttButton.Click += new System.EventHandler(this.runSttButton_Click);
            // 
            // SttTaskPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.runSttButton);
            this.Controls.Add(this.sttLanguageComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "SttTaskPaneControl";
            this.Size = new System.Drawing.Size(427, 664);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox sttLanguageComboBox;
        private System.Windows.Forms.Button runSttButton;
    }
}
