namespace CapybaraTranslateAddin.UI
{
    partial class TtsTaskPaneControl
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.voiceComboBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveToTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cellValueForFilenameTextBox = new System.Windows.Forms.TextBox();
            this.cellValueForFilenameToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.runTtsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Voice:";
            // 
            // voiceComboBox
            // 
            this.voiceComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.voiceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.voiceComboBox.FormattingEnabled = true;
            this.voiceComboBox.Location = new System.Drawing.Point(185, 82);
            this.voiceComboBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.voiceComboBox.Name = "voiceComboBox";
            this.voiceComboBox.Size = new System.Drawing.Size(395, 31);
            this.voiceComboBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(58, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Save to:";
            // 
            // saveToTextBox
            // 
            this.saveToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveToTextBox.Location = new System.Drawing.Point(185, 150);
            this.saveToTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.saveToTextBox.Name = "saveToTextBox";
            this.saveToTextBox.Size = new System.Drawing.Size(395, 30);
            this.saveToTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(58, 232);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(247, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Use cell value for filename:";
            // 
            // cellValueForFilenameTextBox
            // 
            this.cellValueForFilenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cellValueForFilenameTextBox.Location = new System.Drawing.Point(311, 229);
            this.cellValueForFilenameTextBox.Name = "cellValueForFilenameTextBox";
            this.cellValueForFilenameTextBox.Size = new System.Drawing.Size(269, 30);
            this.cellValueForFilenameTextBox.TabIndex = 5;
            this.cellValueForFilenameTextBox.MouseEnter += new System.EventHandler(this.cellValueForFilenameTextBox_MouseEnter);
            this.cellValueForFilenameTextBox.MouseLeave += new System.EventHandler(this.cellValueForFilenameTextBox_MouseLeave);
            // 
            // runTtsButton
            // 
            this.runTtsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.runTtsButton.ForeColor = System.Drawing.Color.Black;
            this.runTtsButton.Location = new System.Drawing.Point(62, 303);
            this.runTtsButton.Name = "runTtsButton";
            this.runTtsButton.Size = new System.Drawing.Size(518, 42);
            this.runTtsButton.TabIndex = 6;
            this.runTtsButton.Text = "Run";
            this.runTtsButton.UseVisualStyleBackColor = true;
            this.runTtsButton.Click += new System.EventHandler(this.runTtsButton_Click);
            // 
            // TtsTaskPaneControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.Controls.Add(this.runTtsButton);
            this.Controls.Add(this.cellValueForFilenameTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.saveToTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.voiceComboBox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "TtsTaskPaneControl";
            this.Size = new System.Drawing.Size(640, 996);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox voiceComboBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox saveToTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cellValueForFilenameTextBox;
        private System.Windows.Forms.ToolTip cellValueForFilenameToolTip;
        private System.Windows.Forms.Button runTtsButton;
    }
}
