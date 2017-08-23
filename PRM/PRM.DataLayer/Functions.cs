using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.EntityClient;
using System.Data.Metadata.Edm;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Globalization;

namespace PRM.DataLayer
{
    public static class Functions
    {
        #region Encryptor
        private static byte[] Key = { 91, 93, 19, 39, 110, 195, 123, 98, 101, 213, 5, 50, 52, 92, 193, 133, 193, 111, 221, 164, 58, 128, 89, 48, 97, 154, 83, 187, 111, 164, 171, 74 };
        private static byte[] IV = { 10, 61, 235, 120, 122, 121, 82, 248, 15, 121, 196, 212, 176, 46, 54, 85 };

        private static byte[] Encrypt(byte[] clearData)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(clearData, 0, clearData.Length);
            cs.Close();
            byte[] encryptedData = ms.ToArray();
            return encryptedData;
        }
        private static byte[] Decrypt(byte[] cipherData)
        {
            MemoryStream ms = new MemoryStream();
            Rijndael alg = Rijndael.Create();
            alg.Key = Key;
            alg.IV = IV;
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(cipherData, 0, cipherData.Length);
            cs.Close();
            byte[] decryptedData = ms.ToArray();
            return decryptedData;
        }
        public static string EncryptString(string clearText)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            byte[] encryptedData = Encrypt(clearBytes);
            return Convert.ToBase64String(encryptedData);
        }
        public static string DecryptString(string cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            byte[] decryptedData = Decrypt(cipherBytes);
            return Encoding.Unicode.GetString(decryptedData);
        }
        public static string MD5(string text)
        {
            byte[] result = new byte[text.Length];
            MD5 md = new MD5CryptoServiceProvider();
            UTF8Encoding encode = new UTF8Encoding();
            result = md.ComputeHash(encode.GetBytes(text));

            return BitConverter.ToString(result).Replace("-", "");

        }
        public static string EmailReplace(string email)
        {
            return email.Replace("ç", "c").Replace("ğ", "g").Replace("ı", "i").Replace("ö", "o").Replace("ş", "s").Replace("ü", "u");
        }
        #endregion
        public static DateTime GetDate()
        { // server yurt disinda oldugundan tarih ayari yapalim diye
            return DateTime.Now;
        }

        
    }
  
}
