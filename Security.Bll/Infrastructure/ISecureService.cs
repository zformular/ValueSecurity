using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Security.Bll.Infrastructure
{
    public interface ISecureService
    {
        /// <summary>
        ///  添加账号
        /// </summary>
        /// <param name="account"></param>
        /// <param name="password"></param>
        String AddAccount(String account, String password);

        /// <summary>
        ///  获得编码后的账号
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        String GetEncryptedAccount(String account);

        /// <summary>
        ///  获得密码
        /// </summary>
        /// <param name="account"></param>
        /// <returns></returns>
        String[] GetPassword(String account);
    }
}
