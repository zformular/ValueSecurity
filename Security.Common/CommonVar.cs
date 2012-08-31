using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Security.Common
{
    public class CommonVar
    {
        /// <summary>
        ///  项目根目录
        /// </summary>
        public static String BaseUrl = AppDomain.CurrentDomain.BaseDirectory;

        /// <summary>
        ///  项目输出路径
        /// </summary>
        public static String OutPut = @"D:\Value Program\Security File";

        /// <summary>
        ///  DES加密公钥
        /// </summary>
        public static String DESKey = "FORMULAR";
    }
}
