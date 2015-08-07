using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using SingCn.Ex51cto.Config;
using System.Windows.Forms;
using System.Drawing;
using Newtonsoft.Json;
using System.Threading;

namespace SingCn.Ex51cto.Deal
{
    public class DoMain
    {
        #region 批量刷博客积分
        public static void DoCoin(RichTextBox rtbLog, string userid, int count)
        {
            try
            {
                for (int index = 0; index < count; index++)
                {
                    DoLog.OutMsg(rtbLog, "开始读取列表", Color.Black);
                    string html = DoHtml.GetPage("http://blog.51cto.com/all/2201536/page/1");
                    int postsCount = int.Parse(DoTopic.GetPostsCount(html));
                    DoLog.OutMsg(rtbLog, "读取完毕，共有" + postsCount + "页博文", Color.Black);
                    for (int i = 1; i <= postsCount; i++)
                    {
                        DoLog.OutMsg(rtbLog, "正在操作第" + i + "页博文", Color.Black);
                        List<Topic> topicVo = DoTopic.GetPostsVo(html, "class=\"artList_tit\"><a href=\"/" + userid + "/([\\d]*?)\">[\\s\\S]*?</a>");
                        foreach (Topic t in topicVo)
                        {
                            int topicId = int.Parse(t.TopicId);
                            DoLog.OutMsg(rtbLog, "正在刷[" + t.TopicId + "]博文", Color.Black);
                            DoHtml.PostReply(t.TopicId, "支持楼主" + DateTime.Now.ToString(), "匿名");
                            Thread.Sleep(1000);
                        }
                        if (i != postsCount)
                        {
                            html = DoHtml.GetPage("http://blog.51cto.com/all/2201536/page/" + (i + 1));
                        }

                    }
                }
                DoLog.OutMsg(rtbLog, "操作完成！", Color.Black);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region 批量刷阅读量
        public static void DoRush(RichTextBox rtbLog,int start,int end,string userid,int count)
        {
            try
            {
                DoLog.OutMsg(rtbLog, "开始读取列表", Color.Black);
                string html = DoHtml.GetPage("http://blog.51cto.com/all/2201536/page/1");
                int postsCount = int.Parse(DoTopic.GetPostsCount(html));
                DoLog.OutMsg(rtbLog, "读取完毕，共有" + postsCount+"页博文", Color.Black);
                for (int i = 1; i <= postsCount; i++)
                {
                    DoLog.OutMsg(rtbLog, "正在操作第" + i + "页博文", Color.Black);
                    List<Topic> topicVo = DoTopic.GetPostsVo(html, "class=\"artList_tit\"><a href=\"/" + userid + "/([\\d]*?)\">[\\s\\S]*?</a>");
                    foreach (Topic t in topicVo)
                    {
                        int topicId = int.Parse(t.TopicId);
                        if (topicId < start && topicId >= end)
                        {
                            continue;
                        }
                        DoLog.OutMsg(rtbLog, "正在刷[" + t.TopicId + "]博文", Color.Black);
                        for (int j = 0; j < count; j++)
                        {
                            DoLog.OutMsg(rtbLog, "正在刷[" + t.TopicId + "]博文,第"+(j+1)+"次。", Color.Black);
                            DoHtml.PostPage("http://blog.51cto.com/js/header.php","uid=" +userid + "&tid=" + t.TopicId);
                            Thread.Sleep(800);
                        }
                    }
                    if (i != postsCount)
                    {
                          html = DoHtml.GetPage("http://blog.51cto.com/all/2201536/page/"+(i+1));
                    }
                  
                }
                DoLog.OutMsg(rtbLog, "操作完成！", Color.Black);
            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region 批量赞
        public static void TryLogin(RichTextBox rtbLog)
        {
            try
            {
                for (int i = 1; i <= 10; i++)
                {
                    try
                    {
                        DoLog.OutMsg(rtbLog,DoLogin.TestLogin(DoHtml.GetUsers(i.ToString())), Color.Black); ;
                        Thread.Sleep(500);
                    }
                    catch (Exception)
                    {
                        continue;
                    }


                }

            }
            catch (Exception)
            {

                throw;
            }
        }

        #endregion
        #region 批量顶赞
        public static void Go(RichTextBox rtbLog, int maxPageNum)
        {
            try
            {

                DoLog.OutMsg(rtbLog, "开始加载回复列表", Color.Black);
                //获取回复列表
                List<Reply> replyVo = DoReply.GetReplyVo();
                //判断回复列表
                if (replyVo == null)
                {
                    DoLog.OutMsg(rtbLog, "回复列表为空或路径出错。", Color.Red);
                    return;
                }
                DoLog.OutMsg(rtbLog, "回复列表加载成功，共有" + replyVo.Count + "条回复。", Color.Green);

                int reId = 0;
                int doid = 1;
                for (int i = maxPageNum; i >= 1; i--)
                {
                    DoLog.OutMsg(rtbLog, "开始获取第" + i + "页的博文列表", Color.Black);
                    string html = DoHtml.GetPostsListView(i.ToString(CultureInfo.InvariantCulture));
                    List<Topic> topicVo = DoTopic.GetPostsVo(html);
                    DoLog.OutMsg(rtbLog, "第" + i + "页的" + topicVo.Count + "条博文加载成功.", Color.Black);
                    for (int index = 0; index < topicVo.Count; index++)
                    {
                        try
                        {

                            reId = (reId == replyVo.Count) ? 0 : reId;
                            string postResult = DoHtml.PostReply(topicVo[index].TopicId, replyVo[reId].Text);
                            ;
                            if (postResult.IndexOf("成功", System.StringComparison.Ordinal) > -1)
                            {
                                DoLog.OutMsg(rtbLog, doid + "--[" + topicVo[index].TopicId + "]:" + postResult,
                                             Color.Green);
                            }
                            else
                            {
                                DoLog.OutMsg(rtbLog, doid + "--[" + topicVo[index].TopicId + "]:" + postResult,
                                             Color.Red);
                            }
                            doid++;
                            reId++;
                        }
                        catch (Exception)
                        {
                            continue;
                        }
                    }
                    DoLog.OutMsg(rtbLog, "第" + i + "页已经赞顶完毕。", Color.Black);
                }
                DoLog.OutMsg(rtbLog, "操作成功完成，凯旋归来。", Color.Green);

            }
            catch (Exception)
            {
                return;
            }
        }
        #endregion
        #region 送礼物
        public static void SendGift(RichTextBox rtbLog, int maxCount)
        {
            try
            {
                DoHtml.SendGift(DoGift.GetOnlineVo(DoHtml.GetOnline()), "送个礼物以表喜欢~");

            }
            catch (Exception)
            {

            }
        }
        #endregion 送礼物
        #region 冒充别人回复
        public static void NullRe(string username, string blogid, string content)
        {
            try
            {
                DoHtml.PostReply(blogid, content, username);

            }
            catch (Exception)
            {

            }
        }
        #endregion
        #region 自动答题
        public static void AutoTest(RichTextBox rtbLog)
        {
            for (int i = 1; i < 1335; i++)
            {
                try
                {
                    string str = DoHtml.PostAnswer(i.ToString(),
                                                   DoAnswer.GetAnswerJData(
                                                       DoAnswer.GetQuestion(DoHtml.GetAnswer(i.ToString())),
                                                       i.ToString()));
                    DoLog.OutMsg(rtbLog, str, Color.Green);
                    Thread.Sleep(2000);
                }
                catch (Exception)
                { 
                    continue;
                }

            }
        }
        #endregion
        #region 批量赞
        public static void Fav(RichTextBox rtbLog, int startTid,int endTid)
        {
            try
            {
                for (int i = startTid; i <= endTid; i++)
                {
                    try
                    {
                        string iStr = i.ToString(CultureInfo.InvariantCulture);
                        if (DoHtml.Fav(iStr).IndexOf("我", StringComparison.Ordinal) >= 0)
                        {
                            DoLog.OutMsg(rtbLog, iStr + ":成功", Color.Green);
                        }
                        else if (DoHtml.Fav(iStr) == "-3")
                        {
                            DoLog.OutMsg(rtbLog, iStr + ":赞过了", Color.Green);
                        }
                        else
                        {
                            DoLog.OutMsg(rtbLog, iStr + ":失败，可能不存在", Color.Green);
                        }
                        Thread.Sleep(500);
                    }
                    catch (Exception)
                    {
                        continue;
                    }

                    
                }
                
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        #endregion
    }
}
