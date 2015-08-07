using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using SingCn.Ex51cto.Config;

namespace SingCn.Ex51cto.Deal
{
    public class DoAnswer
    {

        public static List<Question> GetQuestion(string html, string strPattern = "var[\\s]topicListVal[\\s]= ([\\s\\S]*?);[\\s]-->")
        {
            try
            {
                if (Regex.IsMatch(html, strPattern))
                {
                    string result = Regex.Match(html, strPattern).Groups[1].Value;
                    var rs = JsonConvert.DeserializeObject<Examination>(result);
                    return rs.TopicListVal;
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }


        public static string GetAnswerJData(List<Question> qList,string examId)
        {
            if (qList == null)
            {
                return "{\"rl\": \"0|0|0|0|0|0|0|0|0|0\", \"s\": " + examId + "}";
            }
            string jData = "{\"rl\": \"";
            //0|0|0|0|0|0|0|0|0|0\", \"s\": " + examId + "}";
            for (int i = 0; i < qList.Count; i++)
            {
                jData+=qList[i].Result + "|";
            }
            jData = jData.Remove(jData.Length - 1, 1);
            jData += "\", \"s\": " + examId + "}";
            return jData;
        }
    }
}
