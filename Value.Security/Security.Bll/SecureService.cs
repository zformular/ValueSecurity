using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Security.Bll.Infrastructure;
using Security.DAl;
using Security.Common;
using System.IO;
using ValueHelper.EncryptHelper;

namespace Security.Bll
{
    public class SecureService : ISecureService
    {
        SecureDAO secureDAO;

        public SecureService()
        {
            var fileFullName = CommonVar.BaseUrl;
            fileFullName = Path.Combine(fileFullName, "Data");
            if (!Directory.Exists(fileFullName))
                Directory.CreateDirectory(fileFullName);

            fileFullName = Path.Combine(fileFullName, "secure.dat");
            secureDAO = new SecureDAO(fileFullName);
        }

        #region ISecureService 成员

        public String AddAccount(string account, string password)
        {
            account = DESHelper.Encrypt(account, CommonVar.DESKey);
            password = DESHelper.Encrypt(password, CommonVar.DESKey);
            secureDAO.AddAccount(account, password);
            return account;
        }

        public String GetEncryptedAccount(String account)
        {
            account = DESHelper.Encrypt(account, CommonVar.DESKey);
            return account;
        }

        public String[] GetPassword(string account)
        {
            var passwords = secureDAO.GetPassword(account);
            for (int index = 0; index < passwords.Length; index++)
                passwords[index] = DESHelper.Decrypt(passwords[index], CommonVar.DESKey);
            return passwords;
        }

        #endregion
    }
}
