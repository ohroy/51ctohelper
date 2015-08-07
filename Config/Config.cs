using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace SingCn.Ex51cto.Config
{
    public class User
    {
        /// <summary>
        /// Cookie
        /// </summary>
        /// 
        public static string Cookie = File.ReadAllText(Directory.GetCurrentDirectory() + "\\Config\\Cookies");
    }
}
