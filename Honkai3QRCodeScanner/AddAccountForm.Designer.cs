namespace Honkai3QRCodeScanner
{
    partial class AddAccountForm
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountValue = new System.Windows.Forms.TextBox();
            this.PasswordValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SaveBtn = new System.Windows.Forms.Button();
            this.CaptchaBtn = new System.Windows.Forms.Button();
            this.CaptchaValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 182);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(219, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabel
            // 
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(65, 17);
            this.StatusLabel.Text = "等待验证...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "账号";
            // 
            // AccountValue
            // 
            this.AccountValue.Location = new System.Drawing.Point(60, 16);
            this.AccountValue.Name = "AccountValue";
            this.AccountValue.Size = new System.Drawing.Size(129, 23);
            this.AccountValue.TabIndex = 2;
            // 
            // PasswordValue
            // 
            this.PasswordValue.Location = new System.Drawing.Point(60, 45);
            this.PasswordValue.Name = "PasswordValue";
            this.PasswordValue.PasswordChar = '*';
            this.PasswordValue.Size = new System.Drawing.Size(129, 23);
            this.PasswordValue.TabIndex = 4;
            this.PasswordValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.PasswordValue_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "密码";
            // 
            // SaveBtn
            // 
            this.SaveBtn.Location = new System.Drawing.Point(60, 74);
            this.SaveBtn.Name = "SaveBtn";
            this.SaveBtn.Size = new System.Drawing.Size(129, 23);
            this.SaveBtn.TabIndex = 5;
            this.SaveBtn.Text = "保存";
            this.SaveBtn.UseVisualStyleBackColor = true;
            this.SaveBtn.Click += new System.EventHandler(this.SaveBtn_Click);
            // 
            // CaptchaBtn
            // 
            this.CaptchaBtn.Enabled = false;
            this.CaptchaBtn.Location = new System.Drawing.Point(60, 149);
            this.CaptchaBtn.Name = "CaptchaBtn";
            this.CaptchaBtn.Size = new System.Drawing.Size(129, 23);
            this.CaptchaBtn.TabIndex = 6;
            this.CaptchaBtn.Text = "获取验证码";
            this.CaptchaBtn.UseVisualStyleBackColor = true;
            this.CaptchaBtn.Click += new System.EventHandler(this.CaptchaBtn_Click);
            // 
            // CaptchaValue
            // 
            this.CaptchaValue.Enabled = false;
            this.CaptchaValue.Location = new System.Drawing.Point(60, 120);
            this.CaptchaValue.Name = "CaptchaValue";
            this.CaptchaValue.Size = new System.Drawing.Size(129, 23);
            this.CaptchaValue.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "验证码";
            // 
            // AddAccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(219, 204);
            this.Controls.Add(this.CaptchaValue);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CaptchaBtn);
            this.Controls.Add(this.SaveBtn);
            this.Controls.Add(this.PasswordValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.AccountValue);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.statusStrip1);
            this.Name = "AddAccountForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加账号";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private StatusStrip statusStrip1;
        private ToolStripStatusLabel StatusLabel;
        private Label label1;
        private TextBox AccountValue;
        private TextBox PasswordValue;
        private Label label2;
        private Button SaveBtn;
        private Button CaptchaBtn;
        private TextBox CaptchaValue;
        private Label label3;
    }
}