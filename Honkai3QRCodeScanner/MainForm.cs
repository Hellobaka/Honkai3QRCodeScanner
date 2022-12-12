using BH3_QRCodeScanner;

namespace Honkai3QRCodeScanner
{
    public partial class MainForm : Form
    {
        public List<string> AccountList { get; set; } = new();

        public string Version => VersionValue.Text;

        private BSGameSDK BSGameSDK { get; set; }

        private QRScanner Scanner { get; set; }

        private string Account => AccountSelector.SelectedItem.ToString();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddAccountBtn_Click(object sender, EventArgs e)
        {
            AddAccountForm form = new();
            form.ShowDialog();
            LoadAccountList();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadAccountList();
            VersionValue.Text = ConfigHelper.GetConfig("BH3Ver", "6.3.0");
            string last = ConfigHelper.GetConfig("LastAccount", "");
            if (last != "")
            {
                AccountSelector.SelectedIndex = AccountList.IndexOf(last);
            }
        }

        private void LoadAccountList()
        {
            AccountList.Clear();
            AccountSave.LoadAccount();
            foreach (var item in AccountSave.Accounts)
            {
                AccountList.Add(item.Key);
                AccountSelector.Items.Add(item.Key);
            }
        }

        private void RemoveAccountBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ȷ��Ҫɾ������˺���", "�ţ�", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }
            if (AccountSelector.SelectedIndex == -1)
            {
                return;
            }
            if (AccountList.Any(x => x == Account))
            {
                AccountSave.RemoveAccount(Account);
            }
            LoadAccountList();
        }

        private void ScanBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Version))
            {
                MessageBox.Show("�汾��Ϊ��", "�ţ�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (AccountSelector.SelectedIndex < 0)
            {
                MessageBox.Show("�˺�Ϊ��", "�ţ�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (AccountSave.Accounts.ContainsKey(Account) is false)
            {
                MessageBox.Show("�˺Ų�����", "�ţ�", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ConfigHelper.SetConfig("LastAccount", Account);
            ConfigHelper.SetConfig("BH3Ver", Version);
            Helper.BH3Ver = Version;
            LoginAndScan();
        }

        private void LoginAndScan()
        {
            string password = AccountSave.Accounts[Account];
            StatusLabel.Text = "���ڵ�¼...";
            BSGameSDK = new BSGameSDK(Account, password);
            new Thread(() =>
            {
                var r = BSGameSDK.Login();
                if (r["code"].ToString() == "0")
                {
                    Scanner = new QRScanner(r["uid"].ToString(), r["access_key"].ToString());
                    Scanner.Bili_Login();
                    Invoke(() => StatusLabel.Text = "��¼�ɹ�������ɨ��...");
                    bool result = ScanQRCode();
                    if (!result)
                    {
                        Invoke(() => MessageBox.Show("��¼ʧ���ˣ����Գ������µ�¼������ε�¼ʧ�ܳ���ɾ���˺��������", "�ţ�", MessageBoxButtons.OK, MessageBoxIcon.Error));
                        return;
                    }
                }
                else
                {
                    Invoke(() => StatusLabel.Text = $"��¼ʧ�� code={r["code"]} msg={r["msg"]}");
                    Invoke(() => MessageBox.Show("��¼ʧ���ˣ����Գ������µ�¼������ε�¼ʧ�ܳ���ɾ���˺��������", "�ţ�", MessageBoxButtons.OK, MessageBoxIcon.Error));
                }
            }).Start();
        }

        private bool ScanQRCode()
        {
            Invoke(() => WindowState = FormWindowState.Minimized);
            Thread.Sleep(500);
            Bitmap img = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            using Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0), Screen.PrimaryScreen.Bounds.Size);
            g.Dispose();
            Invoke(() => WindowState = FormWindowState.Normal);
            string url = QRScanner.ScanQRCode(img);
            if (Scanner.ParseURL(url))
            {
                var b = Scanner.DoQRLogin();
                if (b != null && b["retcode"].ToString() == "0")
                    return true;
                Invoke(() => StatusLabel.Text = "�޷�ʶ���ά��...");
                return false;
            }
            else
            {
                Invoke(() => StatusLabel.Text = "�޷�ʶ���ά��...");
                return false;
            }
        }

        private void Invoke(Action action)
        {
            if (InvokeRequired)
            {
                Invoke(new MethodInvoker(action));
            }
            else
            {
                action.Invoke();
            }
        }
    }
}