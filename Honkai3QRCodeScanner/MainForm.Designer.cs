namespace Honkai3QRCodeScanner
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.AccountSelector = new System.Windows.Forms.ComboBox();
            this.AddAccountBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.VersionValue = new System.Windows.Forms.TextBox();
            this.ScanBtn = new System.Windows.Forms.Button();
            this.RemoveAccountBtn = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择账号";
            // 
            // AccountSelector
            // 
            this.AccountSelector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountSelector.FormattingEnabled = true;
            this.AccountSelector.Location = new System.Drawing.Point(89, 15);
            this.AccountSelector.Name = "AccountSelector";
            this.AccountSelector.Size = new System.Drawing.Size(121, 25);
            this.AccountSelector.TabIndex = 1;
            // 
            // AddAccountBtn
            // 
            this.AddAccountBtn.Location = new System.Drawing.Point(216, 15);
            this.AddAccountBtn.Name = "AddAccountBtn";
            this.AddAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.AddAccountBtn.TabIndex = 2;
            this.AddAccountBtn.Text = "添加账号";
            this.AddAccountBtn.UseVisualStyleBackColor = true;
            this.AddAccountBtn.Click += new System.EventHandler(this.AddAccountBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "崩坏3版本号";
            // 
            // VersionValue
            // 
            this.VersionValue.Location = new System.Drawing.Point(89, 72);
            this.VersionValue.Name = "VersionValue";
            this.VersionValue.Size = new System.Drawing.Size(121, 23);
            this.VersionValue.TabIndex = 4;
            // 
            // ScanBtn
            // 
            this.ScanBtn.Location = new System.Drawing.Point(216, 72);
            this.ScanBtn.Name = "ScanBtn";
            this.ScanBtn.Size = new System.Drawing.Size(75, 23);
            this.ScanBtn.TabIndex = 5;
            this.ScanBtn.Text = "扫码";
            this.ScanBtn.UseVisualStyleBackColor = true;
            this.ScanBtn.Click += new System.EventHandler(this.ScanBtn_Click);
            // 
            // RemoveAccountBtn
            // 
            this.RemoveAccountBtn.Location = new System.Drawing.Point(216, 44);
            this.RemoveAccountBtn.Name = "RemoveAccountBtn";
            this.RemoveAccountBtn.Size = new System.Drawing.Size(75, 23);
            this.RemoveAccountBtn.TabIndex = 6;
            this.RemoveAccountBtn.Text = "删除账号";
            this.RemoveAccountBtn.UseVisualStyleBackColor = true;
            this.RemoveAccountBtn.Click += new System.EventHandler(this.RemoveAccountBtn_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 106);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(303, 22);
            this.statusStrip1.TabIndex = 7;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(41, 17);
            this.StatusLabel.Text = "空闲...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 128);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.RemoveAccountBtn);
            this.Controls.Add(this.ScanBtn);
            this.Controls.Add(this.VersionValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AddAccountBtn);
            this.Controls.Add(this.AccountSelector);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主窗体";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private ComboBox AccountSelector;
        private Button AddAccountBtn;
        private Label label2;
        private TextBox VersionValue;
        private Button ScanBtn;
        private Button RemoveAccountBtn;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
    }
}