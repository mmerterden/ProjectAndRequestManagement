using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;

namespace PRM.DataLayer
{
    public class BasePage : Page
    {
        public bool LOGINREQUIRED = true;
        protected User ONLINEUSER
        {
            get
            {
                if (Session["#ONLINEUSER#"] == null)
                {
                    Session["#ONLINEUSER#"] = new User();
                }
                return Session["#ONLINEUSER#"] as User;
            }
            set { Session["#ONLINEUSER#"] = value; }
        }
        protected override void OnInit(EventArgs e)
        {
            if (LOGINREQUIRED)
            {
                if (ONLINEUSER.ISLOGIN())
                {

                }
                else
                {
                    Response.Redirect("/Login.aspx");
                }
            }
            base.OnInit(e);
        }
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
        #region Message
        public enum MessageType
        {
            Info = 1,
            Error = 2,
            Success = 3
        }
        public string MessageSuccess
        {
            get { return "İşleminiz başarıyla tamamlandı"; }
        }
        public string MessageError
        {
            get { return "İşlem esnasında hata oluştu.<br> Lütfen daha sonra tekrar deneyiniz"; }
        }
        public void MessageAdd(MessageType msgType, string msg)
        {
            MessageAdd(msgType, msg, string.Empty, false);
        }
        public void MessageAdd(MessageType msgType, string msg, string focusObject)
        {
            MessageAdd(msgType, msg, focusObject, false);
        }
        public void MessageAdd(MessageType msgType, string msg, bool autoClose)
        {
            MessageAdd(msgType, msg, string.Empty, autoClose);
        }
        public void MessageAdd(MessageType msgType, string msg, string focusObject, bool autoClose)
        {

            if (ScriptManager.GetCurrent(Page).IsInAsyncPostBack)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), "ShowMessage", "ShowMessage('" + msgType.ToString() + "','" + Server.HtmlEncode(msg) + "'," + (string.IsNullOrEmpty(focusObject) ? "null" : "'" + focusObject + "'") + "," + (autoClose ? "3000" : "null") + ")", true);
            }
        }
        #endregion
       

    }

    [Serializable]
    public class User
    {
        public Guid ID { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string FULLNAME { get; set; }
        public string MAIL { get; set; }
        public byte TYPEUSERID { get; set; }
        public Guid? FIRMID { get; set; }
        public bool ISADMIN { get; set; }
        public bool STATUS { get; set; }
        public bool ISLOGIN()
        {
            return ID != Guid.Empty;
        }
    }
}
