namespace CapybaraTranslateAddin.UI
{
    partial class ConfigurationForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DeepLGroupBox = new System.Windows.Forms.GroupBox();
            this.DeepLApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.OpenAiGroupBox = new System.Windows.Forms.GroupBox();
            this.OpenAiApiKeyTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.GoogleGroupBox = new System.Windows.Forms.GroupBox();
            this.LoadFromKeyFileButton = new System.Windows.Forms.Button();
            this.GoogleCredentialsTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.OkButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.DeepLGroupBox.SuspendLayout();
            this.OpenAiGroupBox.SuspendLayout();
            this.GoogleGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // DeepLGroupBox
            // 
            this.DeepLGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeepLGroupBox.Controls.Add(this.DeepLApiKeyTextBox);
            this.DeepLGroupBox.Controls.Add(this.label1);
            this.DeepLGroupBox.Location = new System.Drawing.Point(28, 23);
            this.DeepLGroupBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeepLGroupBox.Name = "DeepLGroupBox";
            this.DeepLGroupBox.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DeepLGroupBox.Size = new System.Drawing.Size(810, 87);
            this.DeepLGroupBox.TabIndex = 0;
            this.DeepLGroupBox.TabStop = false;
            this.DeepLGroupBox.Text = "DeepL (for translation)";
            // 
            // DeepLApiKeyTextBox
            // 
            this.DeepLApiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DeepLApiKeyTextBox.Location = new System.Drawing.Point(117, 39);
            this.DeepLApiKeyTextBox.Name = "DeepLApiKeyTextBox";
            this.DeepLApiKeyTextBox.Size = new System.Drawing.Size(658, 30);
            this.DeepLApiKeyTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "API key:";
            // 
            // OpenAiGroupBox
            // 
            this.OpenAiGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenAiGroupBox.Controls.Add(this.OpenAiApiKeyTextBox);
            this.OpenAiGroupBox.Controls.Add(this.label2);
            this.OpenAiGroupBox.Location = new System.Drawing.Point(28, 136);
            this.OpenAiGroupBox.Name = "OpenAiGroupBox";
            this.OpenAiGroupBox.Size = new System.Drawing.Size(810, 87);
            this.OpenAiGroupBox.TabIndex = 1;
            this.OpenAiGroupBox.TabStop = false;
            this.OpenAiGroupBox.Text = "Open AI (for translation)";
            // 
            // OpenAiApiKeyTextBox
            // 
            this.OpenAiApiKeyTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OpenAiApiKeyTextBox.Location = new System.Drawing.Point(117, 32);
            this.OpenAiApiKeyTextBox.Name = "OpenAiApiKeyTextBox";
            this.OpenAiApiKeyTextBox.Size = new System.Drawing.Size(658, 30);
            this.OpenAiApiKeyTextBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "API key:";
            // 
            // GoogleGroupBox
            // 
            this.GoogleGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoogleGroupBox.Controls.Add(this.LoadFromKeyFileButton);
            this.GoogleGroupBox.Controls.Add(this.GoogleCredentialsTextBox);
            this.GoogleGroupBox.Controls.Add(this.label3);
            this.GoogleGroupBox.Location = new System.Drawing.Point(28, 248);
            this.GoogleGroupBox.Name = "GoogleGroupBox";
            this.GoogleGroupBox.Size = new System.Drawing.Size(810, 431);
            this.GoogleGroupBox.TabIndex = 2;
            this.GoogleGroupBox.TabStop = false;
            this.GoogleGroupBox.Text = "Google (for translation and text-to-speech)";
            // 
            // LoadFromKeyFileButton
            // 
            this.LoadFromKeyFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadFromKeyFileButton.Location = new System.Drawing.Point(555, 32);
            this.LoadFromKeyFileButton.Name = "LoadFromKeyFileButton";
            this.LoadFromKeyFileButton.Size = new System.Drawing.Size(218, 37);
            this.LoadFromKeyFileButton.TabIndex = 4;
            this.LoadFromKeyFileButton.Text = "Load From Key File";
            this.LoadFromKeyFileButton.UseVisualStyleBackColor = true;
            this.LoadFromKeyFileButton.Click += new System.EventHandler(this.LoadFromKeyFileButton_Click);
            // 
            // GoogleCredentialsTextBox
            // 
            this.GoogleCredentialsTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GoogleCredentialsTextBox.Location = new System.Drawing.Point(43, 75);
            this.GoogleCredentialsTextBox.MaxLength = 0;
            this.GoogleCredentialsTextBox.Multiline = true;
            this.GoogleCredentialsTextBox.Name = "GoogleCredentialsTextBox";
            this.GoogleCredentialsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.GoogleCredentialsTextBox.Size = new System.Drawing.Size(730, 331);
            this.GoogleCredentialsTextBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Credentials:";
            // 
            // OkButton
            // 
            this.OkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OkButton.Location = new System.Drawing.Point(583, 707);
            this.OkButton.Name = "OkButton";
            this.OkButton.Size = new System.Drawing.Size(114, 37);
            this.OkButton.TabIndex = 3;
            this.OkButton.Text = "OK";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(724, 707);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(114, 37);
            this.CancelButton.TabIndex = 3;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfigurationForm
            // 
            this.AcceptButton = this.OkButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(144F, 144F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(866, 778);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.GoogleGroupBox);
            this.Controls.Add(this.OpenAiGroupBox);
            this.Controls.Add(this.DeepLGroupBox);
            this.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ConfigurationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Settings";
            this.DeepLGroupBox.ResumeLayout(false);
            this.DeepLGroupBox.PerformLayout();
            this.OpenAiGroupBox.ResumeLayout(false);
            this.OpenAiGroupBox.PerformLayout();
            this.GoogleGroupBox.ResumeLayout(false);
            this.GoogleGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox DeepLGroupBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox DeepLApiKeyTextBox;
        private System.Windows.Forms.GroupBox OpenAiGroupBox;
        private System.Windows.Forms.TextBox OpenAiApiKeyTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox GoogleGroupBox;
        private System.Windows.Forms.TextBox GoogleCredentialsTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button LoadFromKeyFileButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
    }
}