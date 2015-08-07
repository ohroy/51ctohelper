using System.Text.RegularExpressions;

namespace SingCn.Common.Helper
{
    /// <summary>
    /// Regex正则表达式操作类
    /// </summary>
    public class RegexHelper
    {
        #region 验证输入的字符串是否合法
        /// <summary>
        /// 验证输入的字符串是否合法，合法返回true,否则返回false。
        /// </summary>
        /// <param name="strInput">输入的字符串</param>
        /// <param name="strPattern">模式字符串</param>        
        public static bool Validate(string strInput, string strPattern)
        {
            return Regex.IsMatch(strInput, strPattern);
        }
        #endregion

        #region 验证匹配情况并返回值
        /// <summary>
        /// 验证匹配情况并返回值
        /// </summary>
        /// <param name="strInput">源字符串</param>
        /// <param name="strPattern">正在表达式</param>
        /// <param name="strBase">为空时返回的默认值</param>
        /// <returns></returns>
        public static string GetValue(string strInput, string strPattern, string strBase)
        {
            if (Validate(strInput, strPattern))
            {
                return Regex.Match(strInput, strPattern).Groups[1].Value;
            }
            return strBase;
        }
        #endregion

        #region 验证匹配情况并返回值多个组合值
        /// <summary>
        /// 验证匹配情况并返回多个值
        /// </summary>
        /// <param name="strInput">源字符串</param>
        /// <param name="strPattern">正在表达式</param>
        /// <param name="srtspilt">分隔符</param>
        /// <returns></returns>
        public static string GetValues(string strInput, string strPattern, string srtspilt)
        {
            string str = string.Empty;
            foreach (Match item in Regex.Matches(strInput, strPattern))
            {
                str += item.Groups[1].Value + srtspilt;
            }
            if (!string.IsNullOrEmpty(str))
            {
                str = str.Remove(str.Length - 1, 1);
            }
            return str;
        }
        #endregion
    }
}