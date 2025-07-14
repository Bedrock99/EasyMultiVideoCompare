#region Using...

using Microsoft.Win32;
using System.Security.Cryptography;

#endregion

namespace EasyMultiVideoCompare
{
    public class CRegistryConfig
    {
        #region --- Variables ---

        protected string m_strAppName;

        #endregion

        #region --- Constructors ---

        public CRegistryConfig(string strAppName_)
        {
            m_strAppName = strAppName_;
        }

        protected CRegistryConfig() { }

        #endregion

        #region --- Write ---

        public void Write(string strName_, string strValue_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Bedrock99");
            key = key.OpenSubKey("Bedrock99", true);

            key.CreateSubKey(m_strAppName);
            key = key.OpenSubKey(m_strAppName, true);

            key.SetValue(strName_, strValue_);
        }

        public void Write(string strSection_, string strName_, string strValue_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Bedrock99");
            key = key.OpenSubKey("Bedrock99", true);

            key.CreateSubKey(m_strAppName);
            key = key.OpenSubKey(m_strAppName, true);

            key.CreateSubKey(strSection_);
            key = key.OpenSubKey(strSection_, true);

            key.SetValue(strName_, strValue_);
        }

        public void Write(string strSection1_, string strSection2_, string strName_, string strValue_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Bedrock99");
            key = key.OpenSubKey("Bedrock99", true);

            key.CreateSubKey(m_strAppName);
            key = key.OpenSubKey(m_strAppName, true);

            key.CreateSubKey(strSection1_);
            key = key.OpenSubKey(strSection1_, true);

            key.CreateSubKey(strSection2_);
            key = key.OpenSubKey(strSection2_, true);

            key.SetValue(strName_, strValue_);
        }

        public void Write(string strSection1_, string strSection2_, string strSection3_, string strName_, string strValue_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Bedrock99");
            key = key.OpenSubKey("Bedrock99", true);

            key.CreateSubKey(m_strAppName);
            key = key.OpenSubKey(m_strAppName, true);

            key.CreateSubKey(strSection1_);
            key = key.OpenSubKey(strSection1_, true);

            key.CreateSubKey(strSection2_);
            key = key.OpenSubKey(strSection2_, true);

            key.CreateSubKey(strSection3_);
            key = key.OpenSubKey(strSection3_, true);

            key.SetValue(strName_, strValue_);
        }

        public void Write(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, string strValue_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);

            key.CreateSubKey("Bedrock99");
            key = key.OpenSubKey("Bedrock99", true);

            key.CreateSubKey(m_strAppName);
            key = key.OpenSubKey(m_strAppName, true);

            key.CreateSubKey(strSection1_);
            key = key.OpenSubKey(strSection1_, true);

            key.CreateSubKey(strSection2_);
            key = key.OpenSubKey(strSection2_, true);

            key.CreateSubKey(strSection3_);
            key = key.OpenSubKey(strSection3_, true);

            key.CreateSubKey(strSection4_);
            key = key.OpenSubKey(strSection4_, true);

            key.SetValue(strName_, strValue_);
        }

        #endregion

        #region --- Read String ---

        public string Read(string strName_, string strDefault_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey("Bedrock99", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(m_strAppName, true);
            if (key == null) return strDefault_;

            if (key.GetValue(strName_) == null) return strDefault_;
            return key.GetValue(strName_).ToString();
        }

        public string Read(string strSection_, string strName_, string strDefault_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey("Bedrock99", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(m_strAppName, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection_, true);
            if (key == null) return strDefault_;

            if (key.GetValue(strName_) == null) return strDefault_;
            return key.GetValue(strName_).ToString();
        }

        public string Read(string strSection1_, string strSection2_, string strName_, string strDefault_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey("Bedrock99", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(m_strAppName, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection1_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection2_, true);
            if (key == null) return strDefault_;

            if (key.GetValue(strName_) == null) return strDefault_;
            return key.GetValue(strName_).ToString();
        }

        public string Read(string strSection1_, string strSection2_, string strSection3_, string strName_, string strDefault_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey("Bedrock99", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(m_strAppName, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection1_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection2_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection3_, true);
            if (key == null) return strDefault_;

            if (key.GetValue(strName_) == null) return strDefault_;
            return key.GetValue(strName_).ToString();
        }

        public string Read(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, string strDefault_)
        {
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey("Bedrock99", true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(m_strAppName, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection1_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection2_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection3_, true);
            if (key == null) return strDefault_;

            key = key.OpenSubKey(strSection4_, true);
            if (key == null) return strDefault_;

            if (key.GetValue(strName_) == null) return strDefault_;
            return key.GetValue(strName_).ToString();
        }

        #endregion

        #region --- Read Encrypted String ---

        public string ReadEncrypted(string strName_, string strDefault_, string strPassword_)
        {
            return DecryptString(Read(strName_, EncryptString(strDefault_, strPassword_)), strPassword_);
        }

        public string ReadEncrypted(string strSection_, string strName_, string strDefault_, string strPassword_)
        {
            return DecryptString(Read(strSection_, strName_, EncryptString(strDefault_, strPassword_)), strPassword_);
        }

        public string ReadEncrypted(string strSection1_, string strSection2_, string strName_, string strDefault_, string strPassword_)
        {
            return DecryptString(Read(strSection1_, strSection2_, strName_, EncryptString(strDefault_, strPassword_)), strPassword_);
        }

        public string ReadEncrypted(string strSection1_, string strSection2_, string strSection3_, string strName_, string strDefault_, string strPassword_)
        {
            return DecryptString(Read(strSection1_, strSection2_, strSection3_, strName_, EncryptString(strDefault_, strPassword_)), strPassword_);
        }

        public string ReadEncrypted(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, string strDefault_, string strPassword_)
        {
            return DecryptString(Read(strSection1_, strSection2_, strSection3_, strSection4_, strName_, EncryptString(strDefault_, strPassword_)), strPassword_);
        }

        #endregion

        #region --- Read Int ---

        public int ReadInt(string strName_, int iDefault_)
        {
            return Convert.ToInt32(Read(strName_, iDefault_.ToString()));
        }

        public int ReadInt(string strSection_, string strName_, int iDefault_)
        {
            return Convert.ToInt32(Read(strSection_, strName_, iDefault_.ToString()));
        }

        public int ReadInt(string strSection1_, string strSection2_, string strName_, int iDefault_)
        {
            return Convert.ToInt32(Read(strSection1_, strSection2_, strName_, iDefault_.ToString()));
        }

        public int ReadInt(string strSection1_, string strSection2_, string strSection3_, string strName_, int iDefault_)
        {
            return Convert.ToInt32(Read(strSection1_, strSection2_, strSection3_, strName_, iDefault_.ToString()));
        }

        public int ReadInt(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, int iDefault_)
        {
            return Convert.ToInt32(Read(strSection1_, strSection2_, strSection3_, strSection4_, strName_, iDefault_.ToString()));
        }

        #endregion

        #region --- Read Bool ---

        public bool ReadBool(string strName_, bool bDefault_)
        {
            return Convert.ToBoolean(Read(strName_, bDefault_.ToString()));
        }

        public bool ReadBool(string strSection_, string strName_, bool bDefault_)
        {
            return Convert.ToBoolean(Read(strSection_, strName_, bDefault_.ToString()));
        }

        public bool ReadBool(string strSection1_, string strSection2_, string strName_, bool bDefault_)
        {
            return Convert.ToBoolean(Read(strSection1_, strSection2_, strName_, bDefault_.ToString()));
        }

        public bool ReadBool(string strSection1_, string strSection2_, string strSection3_, string strName_, bool bDefault_)
        {
            return Convert.ToBoolean(Read(strSection1_, strSection2_, strSection3_, strName_, bDefault_.ToString()));
        }

        public bool ReadBool(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, bool bDefault_)
        {
            return Convert.ToBoolean(Read(strSection1_, strSection2_, strSection3_, strSection4_, strName_, bDefault_.ToString()));
        }

        #endregion

        #region --- Read Long ---

        public long ReadLong(string strName_, long lDefault_)
        {
            return Convert.ToInt64(Read(strName_, lDefault_.ToString()));
        }

        public long ReadLong(string strSection_, string strName_, long lDefault_)
        {
            return Convert.ToInt64(Read(strSection_, strName_, lDefault_.ToString()));
        }

        public long ReadLong(string strSection1_, string strSection2_, string strName_, long lDefault_)
        {
            return Convert.ToInt64(Read(strSection1_, strSection2_, strName_, lDefault_.ToString()));
        }

        public long ReadLong(string strSection1_, string strSection2_, string strSection3_, string strName_, long lDefault_)
        {
            return Convert.ToInt64(Read(strSection1_, strSection2_, strSection3_, strName_, lDefault_.ToString()));
        }

        public long ReadLong(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, long lDefault_)
        {
            return Convert.ToInt64(Read(strSection1_, strSection2_, strSection3_, strSection4_, strName_, lDefault_.ToString()));
        }

        #endregion

        #region --- Read Double ---

        public double ReadDouble(string strName_, double dblDefault_)
        {
            return Convert.ToDouble(Read(strName_, dblDefault_.ToString()));
        }

        public double ReadDouble(string strSection_, string strName_, double dblDefault_)
        {
            return Convert.ToDouble(Read(strSection_, strName_, dblDefault_.ToString()));
        }

        public double ReaReadDoubledBool(string strSection1_, string strSection2_, string strName_, double dblDefault_)
        {
            return Convert.ToDouble(Read(strSection1_, strSection2_, strName_, dblDefault_.ToString()));
        }

        public double ReadDouble(string strSection1_, string strSection2_, string strSection3_, string strName_, double dblDefault_)
        {
            return Convert.ToDouble(Read(strSection1_, strSection2_, strSection3_, strName_, dblDefault_.ToString()));
        }

        public double ReadDouble(string strSection1_, string strSection2_, string strSection3_, string strSection4_, string strName_, double dblDefault_)
        {
            return Convert.ToDouble(Read(strSection1_, strSection2_, strSection3_, strSection4_, strName_, dblDefault_.ToString()));
        }

        #endregion

        #region -- SaveWindow --

        public void SaveWindow(Form f_, string strSection_)
        {
            Write(strSection_, f_.Name, "SizeX", f_.Size.Width.ToString());
            Write(strSection_, f_.Name, "SizeY", f_.Size.Height.ToString());
            Write(strSection_, f_.Name, "PosX", f_.Location.X.ToString());
            Write(strSection_, f_.Name, "PosY", f_.Location.Y.ToString());
            Write(strSection_, f_.Name, "Maximized", (f_.WindowState == FormWindowState.Maximized).ToString());
        }

        public void SaveWindow(Form f_, string strSection_, SplitContainer[] scs_)
        {
            SaveWindow(f_, strSection_);
            foreach (SplitContainer sc in scs_)
            {
                Write(strSection_, f_.Name, sc.Name, "Horizontal", (sc.Orientation == Orientation.Horizontal).ToString());
                Write(strSection_, f_.Name, sc.Name, "SplitterDistance", sc.SplitterDistance.ToString());
            }
        }

        #endregion

        #region -- LoadWindow --

        public void LoadWindow(Form f_, string strSection_, bool bLoadPos_, bool bLoadSize_)
        {
            if (bLoadSize_)
            {
                int iSizeX = ReadInt(strSection_, f_.Name, "SizeX", f_.Size.Width);
                int iSizeY = ReadInt(strSection_, f_.Name, "SizeY", f_.Size.Height);
                f_.Size = new System.Drawing.Size(iSizeX, iSizeY);
                if (ReadBool(strSection_, f_.Name, "Maximized", false))
                    f_.WindowState = FormWindowState.Maximized;
                else
                    f_.Size = new System.Drawing.Size(iSizeX, iSizeY);
            }
            if (bLoadPos_)
            {
                int iPosX = ReadInt(strSection_, f_.Name, "PosX", 99999);
                int iPosY = ReadInt(strSection_, f_.Name, "PosY", 99999);
                if (iPosX != 99999 && iPosY != 99999)
                    SetWindowLocation(f_, iPosX, iPosY);
            }
        }

        public void LoadWindow(Form f_, string strSection_, bool bLoadPos_, bool bLoadSize_, SplitContainer[] scs_)
        {
            LoadWindow(f_, strSection_, bLoadPos_, bLoadSize_);
            foreach (SplitContainer sc in scs_)
            {
                if (ReadBool(strSection_, f_.Name, sc.Name, "Horizontal", (sc.Orientation == Orientation.Horizontal)))
                    sc.Orientation = Orientation.Horizontal;
                else
                    sc.Orientation = Orientation.Vertical;
                sc.SplitterDistance = ReadInt(strSection_, f_.Name, sc.Name, "SplitterDistance", sc.SplitterDistance);
            }
        }

        #endregion

        #region --- SetWindowLocation ---

        public static void SetWindowLocation(Form f, int iPosX, int iPosY)
        {
            if (iPosX < Screen.PrimaryScreen.Bounds.Left || iPosX > Screen.PrimaryScreen.Bounds.Right)
                iPosX = 100;
            if (iPosY < Screen.PrimaryScreen.Bounds.Top || iPosY > Screen.PrimaryScreen.Bounds.Bottom)
                iPosY = 100;
            f.StartPosition = FormStartPosition.Manual;
            f.Location = new Point(iPosX, iPosY);
        }

        #endregion

        #region --- String- Encrytion ---

        public static string EncryptString(string clearText, string Password)
        {
            byte[] clearBytes = System.Text.Encoding.Unicode.GetBytes(clearText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] encryptedData = EncryptString(clearBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return Convert.ToBase64String(encryptedData);
        }

        public static string DecryptString(string cipherText, string Password)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes pdb = new PasswordDeriveBytes(Password, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
            byte[] decryptedData = DecryptString(cipherBytes, pdb.GetBytes(32), pdb.GetBytes(16));
            return System.Text.Encoding.Unicode.GetString(decryptedData);
        }

        private static byte[] EncryptString(byte[] clearText, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Aes alg = Aes.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearText, 0, clearText.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }

        private static byte[] DecryptString(byte[] cipherData, byte[] Key, byte[] IV)
        {
            MemoryStream ms = new MemoryStream();
            Aes alg = Aes.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }

        #endregion
    }
}
