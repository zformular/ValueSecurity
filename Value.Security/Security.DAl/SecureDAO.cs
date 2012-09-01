using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ValueHelper;

namespace Security.DAl
{
    public class SecureDAO
    {
        private String fileFullName;
        private FileHelper fileHelper;

        public SecureDAO(String fileFullName)
        {
            this.fileFullName = fileFullName;
            fileHelper = new FileHelper(fileFullName);
            fileHelper.CreateFile(fileFullName);
        }

        public void AddAccount(String account, String password)
        {
            var content = account + " : " + password;
            if (!fileHelper.ContentExsist(content))
                fileHelper.WriteContent(content);
        }

        public String[] GetPassword(String account)
        {
            var accountInfo = fileHelper.ReadContent(account);
            if (accountInfo == String.Empty)
                return new String[1];

            var accountArry = StringHelper.Split(accountInfo, ';');
            var resultArry = new String[accountArry.Length];
            for (int index = 0; index < accountArry.Length; index++)
                resultArry[index] = accountArry[index].Substring(account.Length + 3);

            return resultArry;
        }
    }
}
