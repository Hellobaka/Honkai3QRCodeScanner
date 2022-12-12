using BH3_QRCodeScanner;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Honkai3QRCodeScanner
{
    public partial class AddAccountForm : Form
    {
        public string Account => AccountValue.Text;

        public string Password => PasswordValue.Text;

        public string Captcha => CaptchaValue.Text;

        public string Captcha_Challenge { get; set; }

        public string Captcha_UserID { get; set; }

        private BSGameSDK BSGameSDK { get; set; }

        public AddAccountForm()
        {
            InitializeComponent();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            BSGameSDK = null;
            CaptchaValue.Text = "";
            Captcha_UserID = "";
            Captcha_Challenge = "";
            if(string.IsNullOrEmpty(Account) || string.IsNullOrEmpty(Password))
            {
                MessageBox.Show("账号或密码为空", "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            StatusLabel.Text = "正在验证账号...";
            if(VerifyAccount(Account, Password))
            {
                AccountSave.AddAccount(Account, Password);
                MessageBox.Show("OK", "账号记录成功", MessageBoxButtons.OK, MessageBoxIcon.Information);
                StatusLabel.Text = "记录完成...";
                Close();
            }
        }

        private bool VerifyAccount(string account, string password)
        {
            BSGameSDK = new BSGameSDK(account, password);
            JObject r = null;
            if(Captcha_UserID != "")
            {
                r = BSGameSDK.Login_WithCaptcha(Captcha_Challenge, Captcha_UserID, Captcha);
            }
            else
            {
                r = BSGameSDK.Login();
            }
            if(r == null || r.ContainsKey("code") is false)
            {
                StatusLabel.Text = $"网络错误";
                MessageBox.Show("网络错误", "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if(r.ContainsKey("access_key"))
            {
                return true;
            }
            string code = r["code"].ToString();
            if (code == "500002")
            {
                StatusLabel.Text = $"code={code}, 账号或密码错误";
                MessageBox.Show("账号或密码错误", "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            else
            {
                StatusLabel.Text = $"code={code}{(r.ContainsKey("msg")? ", "+ r["msg"] : "")}";
                if (Captcha_UserID != "")
                {
                    MessageBox.Show("登录失败\n" + r.ToString(), "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("登录失败，或许可以试试验证码", "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CaptchaBtn.Enabled = true;
                    CaptchaValue.Enabled = true;
                }
                return false;
            }
        }

        private void CaptchaBtn_Click(object sender, EventArgs e)
        {
            var captcha = BSGameSDK.Captcha();
            if (captcha.ContainsKey("gt") is false)
            {
                StatusLabel.Text = "验证码获取失败";
                MessageBox.Show("验证码获取失败", "嗯？", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string url = $"https://help.tencentbot.top/geetest/?captcha_type=1&challenge={captcha["challenge"]}&gt={captcha["gt"]}&userid={captcha["gt_user_id"]}&gs=1";
            StatusLabel.Text = "验证码获取成功";
            Captcha_Challenge = captcha["challenge"].ToString();
            Captcha_UserID = captcha["gt_user_id"].ToString();
            MessageBox.Show("请通过完成验证码后，将 validate= 后的内容粘贴到对应框中", "验证码请求", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(url);
        }

        private void PasswordValue_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                SaveBtn.PerformClick();
            }
        }
    }
}
