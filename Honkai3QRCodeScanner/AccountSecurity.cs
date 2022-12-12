using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Honkai3QRCodeScanner
{
    /// <summary>
    /// bilibili账号管理二级封装
    /// </summary>
    public static class AccountSave
    {
        public static Dictionary<string, string> Accounts { get; set; } = new();

        /// <summary>
        /// 对QQ添加一个绑定账号
        /// </summary>
        /// <param name="qq">需要绑定的QQ号</param>
        /// <param name="account">bilibili账号 用户名 手机 邮箱</param>
        /// <param name="password">密码</param>
        public static void AddAccount(string account, string password)
        {
            if (Accounts.ContainsKey(account))
            {
                Accounts[account] = password;
            }
            else
            {
                Accounts.Add(account, password);
            }
            AccountSecurity.SaveData(Accounts);
        }
        /// <summary>
        /// 读取账号列表到内存
        /// </summary>
        public static void LoadAccount()
        {
            Accounts.Clear();
            JObject t = AccountSecurity.LoadData();
            if (t == null)
                t = new JObject();
            foreach (var item in t)
            {
                Accounts.Add(item.Key, item.Value.ToString());
            }
        }
        /// <summary>
        /// 从此QQ的账号列表中移除某个账号
        /// </summary>
        /// <param name="qq">QQ</param>
        /// <param name="account">需要移除的账号</param>
        public static void RemoveAccount(string account)
        {
            if (Accounts.ContainsKey(account))
            {
                if (Accounts.ContainsKey(account))
                {
                    Accounts.Remove(account);
                }
            }
            AccountSecurity.SaveData(Accounts);
        }
    }
    /// <summary>
    /// 账号保存加密
    /// </summary>
    public static class AccountSecurity
    {
        /// <summary>
        /// 异或密钥
        /// </summary>
        const string XOR_KEY = "BOT";
        /// <summary>
        /// 将账号列表加密保存到文件
        /// </summary>
        public static void SaveData(Dictionary<string, string> accounts)
        {
            JObject t = new();
            foreach (var item in accounts)
                t.Add(item.Key.ToString(), item.Value);
            SaveData(t);
        }
        public static void SaveData(JObject account)
        {
            string baseStr = account.ToString(Formatting.None);
            File.WriteAllBytes("account.bin", XorEncrypt(baseStr, XOR_KEY));
        }
        /// <summary>
        /// 读取账号列表
        /// </summary>
        public static JObject LoadData()
        {
            string filepath = "account.bin";
            if (!File.Exists(filepath))
                return null;
            byte[] c = File.ReadAllBytes(filepath);
            return JObject.Parse(Encoding.UTF8.GetString(XorEncrypt(c, XOR_KEY)));
        }
        /// <summary>
        /// 异或循环加密
        /// </summary>
        /// <param name="plainText">需要处理的文本的字节数组</param>
        /// <param name="key">异或密钥</param>
        private static byte[] XorEncrypt(byte[] plainText, string key)
        {
            return XorEncrypt(plainText, Encoding.UTF8.GetBytes(key));
        }
        private static byte[] XorEncrypt(string plainText, string key)
        {
            return XorEncrypt(Encoding.UTF8.GetBytes(plainText), Encoding.UTF8.GetBytes(key));
        }
        private static byte[] XorEncrypt(byte[] plainBytes, byte[] key)
        {
            int index = 0;
            for (int i = 0; i < plainBytes.Length; i++)
            {
                plainBytes[i] = (byte)(plainBytes[i] ^ key[index]);
                index++;
                if (index == key.Length)
                    index = 0;
            }
            return plainBytes;
        }
    }
}
