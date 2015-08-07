using System;
using System.Collections.Generic;
using System.Text;
using SingCn.Ex51cto.Config;
using System.Text.RegularExpressions;
using SingCn.Common.Helper;

namespace SingCn.Ex51cto.Deal
{
    public class DoTopic
    {
        #region
        /// <summary>
        /// 获取博文id
        /// </summary>
        /// <param name="html">网页实体</param>
        /// <param name="strPattern">匹配规则</param>
        /// <returns>列表</returns>
        public static List<Topic> GetPostsVo(string html, string strPattern="favourdiv[\\s\\S]*?zan[\\s\\S]*?tid=\"([\\d]*?)\"[\\s\\S]*?人" )
        {
            List<Topic> topicVo = new List<Topic>();
            MatchCollection mc = Regex.Matches(html, strPattern);
            for (int i = 0; i < mc.Count; i++)
            {
                var tp = new Topic
                    {
                        TopicId = mc[i].Groups[1].Value
                    };
                    topicVo.Add(tp);
            }
            return topicVo;
        }
        #endregion



        #region
        public static string GetPostsCount(string html, string strPattern = "页数 \\( [\\d]+/([\\d]+) \\)</center>")
        {
            return RegexHelper.GetValue(html, strPattern, "1");
        }
        #endregion
    }
}
