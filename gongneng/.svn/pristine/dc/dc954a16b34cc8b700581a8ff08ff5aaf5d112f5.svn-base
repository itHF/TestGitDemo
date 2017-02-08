namespace EncryptUnityDLL
{
    using Microsoft.Win32;
    using System;
    using System.IO;
    using System.Net.NetworkInformation;
    using System.Security.Cryptography;
    using System.Text;

    public class EncryptDLL
    {
        private static byte[] bytes = Encoding.ASCII.GetBytes("T&5,Qosq");

        public static bool checkPass(string inputstring)
        {
            string str = getRightPass();
            if ((inputstring != null) && inputstring.Equals(str))
            {
                RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\rainier");
                key.SetValue("rainierPassKey", inputstring);
                key.Close();
                return true;
            }
            return false;
        }

        public static bool checkPassStart()
        {
            string str = getStoredPass();
            string str2 = getRightPass();
            
            return ((str != null) && str.Equals(str2));
        }

        private static string Decrypt(string cryptedString)
        {
            if (string.IsNullOrEmpty(cryptedString))
            {
                throw new ArgumentNullException("The string which needs to be decrypted can not be null.");
            }
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream(Convert.FromBase64String(cryptedString));
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(bytes, bytes), 0);
            StreamReader reader = new StreamReader(stream2);
            return reader.ReadToEnd();
        }

        private static string Encrypt(string originalString)
        {
            if (string.IsNullOrEmpty(originalString))
            {
                throw new ArgumentNullException("The string which needs to be encrypted can not be null.");
            }
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            StreamWriter writer = new StreamWriter(stream2);
            writer.Write(originalString);
            writer.Flush();
            stream2.FlushFinalBlock();
            writer.Flush();
            return Convert.ToBase64String(stream.GetBuffer(), 0, (int) stream.Length);
        }

        public static string getRightPass()
        {
            string originalString = "";
            int num = 0x3b;
            //byte[] bytes = Encoding.get_ASCII().GetBytes(showLocalMac());
            byte[] bytes = Encoding.ASCII.GetBytes(showLocalMac());
            foreach (byte num3 in bytes)
            {
                originalString = originalString + (num3 + num) + ((char) num).ToString();
                num += 2;
            }
            return Encrypt(originalString);
        }

        private static string getStoredPass()
        {
            return (string) Registry.GetValue(@"HKEY_CURRENT_USER\SOFTWARE\rainier", "rainierPassKey", "the key is not here");
        }

        public static string showLocalMac()
        {
            NetworkInterface[] allNetworkInterfaces = NetworkInterface.GetAllNetworkInterfaces();
            string str = string.Empty;
            foreach (NetworkInterface interface2 in allNetworkInterfaces)
            {
                if (str == string.Empty)
                {
                    str = interface2.GetPhysicalAddress().ToString();
                }
            }
            return str;
        }
    }
}

