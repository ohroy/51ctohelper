using System;
using System.Collections.Generic;
using System.Text;
using SingCn.Ex51cto.Config;
using System.Text.RegularExpressions;

namespace SingCn.Ex51cto.Deal
{
    public class DoGift
    {
        #region

        /// <summary>
        /// 获取微吧列表集合
        /// </summary>
        /// <param name="html"></param>
        /// <param name="strPattern"></param>
        /// <returns></returns>
        public static string GetOnlineVo(string html,
                                         string strPattern = "jpAddFri\\((\\d*?)\\);\"[\\s]title=\"加为好友\">加为好友</a>")
        {
            MatchCollection mc = Regex.Matches(html, strPattern);
            string str = string.Empty;
            for (int i = 0; i < mc.Count; i++)
            {
                str += mc[i].Groups[1].Value + ",";
            }
            if (str.EndsWith(","))
            {
                str=str.Remove(str.Length - 1);
            }
            return str;
        }

        #endregion
    }
}
