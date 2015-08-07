using System.Text;
using SingCn.Common.Helper;
using SingCn.Ex51cto.Config;
using System.Web;

namespace SingCn.Ex51cto.Deal
{
    public class DoHtml
    {


        /// <summary>
        /// 获取在线用户实例
        /// </summary>
        /// <returns>网页实例</returns>
        public static string GetOnline()
        {
            var http = new HttpHelper();
            var item = new HttpItem
                {
                    URL = "http://home.51cto.com/index.php?s=/Friend/online/p/",
                    Cookie = User.Cookie,
                };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }






        public static string GetPage(string url)
        {
            var http = new HttpHelper();
            var item = new HttpItem
            {
                URL = url,
                Cookie = User.Cookie,
            };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }

        public static string PostPage(string url,string data)
        {
            var http = new HttpHelper();
            var item = new HttpItem
            {
                URL = url, //URL     必需项    
                Method = "post", //URL     可选项 默认为Get   
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写   
                Cookie = User.Cookie, //字符串Cookie     可选项 
                Postdata =  data,
                Timeout = 100000, //连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                //用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                Allowautoredirect = true, //是否根据301跳转     可选项   
            };
            HttpResult result = http.GetHtml(item);
            return  result.Html;
        }
        #region 获取51cto用户列表
        /// <summary>
        /// 获取社区在线列表
        /// </summary>
        /// <param name="page">页数</param>
        /// <returns>网页实例</returns>
        public static string GetUsers(string page = "1")
        {
            var http = new HttpHelper();
            var item = new HttpItem
                {
                    URL = "http://bbs.51cto.com/member.php?action=list&listgid=&srchmem=&order=uid&type=&page=" + page,
                    Cookie = User.Cookie,
                };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }

        #endregion




        public static string PostReply(string postsId, string reply, string username = "51CTO助手")
        {
            var http = new HttpHelper();
            var postType = username == "匿名" ? "1" : "0";
            var item = new HttpItem
            {
                URL = "http://rozbo.blog.51cto.com/comment3.php", 
                Method = "post", 
                IsToLower = false,
                Cookie = User.Cookie, 
                //Referer = "http://weiba.weibo.com/10070/t/zstIRyLfE",
                Postdata =
                    "authnum=&tid=" + postsId + "&username=" + HttpUtility.UrlEncode(username, Encoding.UTF8) +
                    "&content=" + HttpUtility.UrlEncode(reply, Encoding.UTF8) + "&niming=" + posttype +
                    "&favour=1&parentid=",
                Timeout = 100000,
                ReadWriteTimeout = 30000,
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8",
                Allowautoredirect = true,

            };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            var html = result.Html;
            return html;
        }




        public static string SendGift(string userId, string reply)
        {
            var http = new HttpHelper();
            var item = new HttpItem
                {
                    URL = "http://home.51cto.com/apps/gift/index.php?s=/Index/send/", //URL     必需项    
                    Method = "post", //URL     可选项 默认为Get   
                    IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写   
                    Cookie = User.Cookie, //字符串Cookie     可选项   
                    Referer = "http://weiba.weibo.com/10070/t/zstIRyLfE", //来源URL     可选项   
                    Postdata =
                        "fri_ids=" + userId + "&sendInfo=" + HttpUtility.UrlEncode(reply, Encoding.UTF8) +
                        "&sendWay=1&giftId=202", //Post数据     可选项GET时不需要写   
                    Timeout = 100000, //连接超时时间     可选项默认为100000    
                    ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                    UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                    //用户的浏览器类型，版本，操作系统     可选项有默认值   
                    ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                    Allowautoredirect = true, //是否根据301跳转     可选项   
                    //CerPath = "d:\123.cer",//证书绝对路径     可选项不需要证书时可以不写这个参数   
                    //Connectionlimit = 1024,//最大连接数     可选项 默认为1024                    ProxyIp = "",//代理服务器ID     可选项 不需要代理 时可以不设置这三个参数    
                    //ProxyPwd = "123456",//代理服务器密码     可选项    
                    //ProxyUserName = "administrator",//代理服务器账户名     可选项  

                };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            var html = result.Html;
            return html;
        }






        /// <summary>
        /// 获取51cto博文列表
        /// </summary>
        /// <param name="page">页码</param>
        /// <returns>网页实体</returns>
        public static string GetPostsListView(string page = "1")
        {
            var http = new HttpHelper();
            var item = new HttpItem
                {
                    URL = "http://blog.51cto.com/original/0/" + page, //URL     必需项    
                    Cookie = User.Cookie,
                    Allowautoredirect = true,
                    ContentType = "application/x-www-form-urlencoded",
                    Accept = " text/html,application/xhtml+xml,application/xml;q=0.9,*/*;q=0.8",
                };
            item.Header.Add("X-Requested-With", "XMLHttpRequest");
            HttpResult result = http.GetHtml(item);
            string html = result.Html;
            return html;
        }






        /// <summary>
        /// 发表答案
        /// </summary>
        /// <param name="questionId">题目id</param>
        /// <param name="jData">答案序列</param>
        /// <returns></returns>
        public static string PostAnswer(string questionId, string jData)
        {
            var http = new HttpHelper();
            var itemGet = new HttpItem
                {
                    URL = "http://selftest.51cto.com/topicplay.php?sid=" + questionId, //URL     必需项    
                    Method = "get", //URL     可选项 默认为Get   
                    IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写   
                    Referer = "http://selftest.51cto.com/subread.php?sid=" + questionId,
                    Cookie = User.Cookie, //字符串Cookie     可选项   
                    Timeout = 100000, //连接超时时间     可选项默认为100000    
                    ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                    UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                    //用户的浏览器类型，版本，操作系统     可选项有默认值   
                    ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                    Allowautoredirect = true, //是否根据301跳转     可选项   
                };
            http.GetHtml(itemGet);
            //
            var itemPost = new HttpItem
            {
                URL = "http://selftest.51cto.com/topicplay.sv.php", //URL     必需项    
                Method = "POST", //URL     可选项 默认为Get   
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写   
                Referer = "http://selftest.51cto.com/topicplay.php", //来源URL     可选项   
                Postdata = "jData="+jData,
                Cookie = User.Cookie, //字符串Cookie     可选项   
                Timeout = 100000, //连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                //用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                Allowautoredirect = true, //是否根据301跳转     可选项   
            };
            return http.GetHtml(itemPost).Html;
        }




        /// <summary>
        /// 获取答案
        /// </summary>
        /// <param name="questionId">题目id</param>
        /// <returns></returns>
        public static string GetAnswer(string questionId)
        {
            var http = new HttpHelper();
            var itemGet = new HttpItem
            {
                URL = "http://selftest.51cto.com/self_showres.php?sid=" + questionId, //URL     必需项    
                Method = "get", //URL     可选项 默认为Get   
                IsToLower = false, //得到的HTML代码是否转成小写     可选项默认转小写   
                Referer = "http://selftest.51cto.com/subread.php?sid=" + questionId,
                Cookie = User.Cookie, //字符串Cookie     可选项   
                Timeout = 100000, //连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                //用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                Allowautoredirect = true, //是否根据301跳转     可选项   
            };
            return http.GetHtml(itemGet).Html;
        }




        public static string Fav(string tid)
        {
            var http = new HttpHelper();
            var itemPost = new HttpItem
            {
                URL = "http://rozbo.blog.51cto.com/mod/favour.php", //URL     必需项    
                Method = "POST", //URL     可选项 默认为Get   
                IsToLower = false,   
                Postdata = "tid=" + tid,
                Cookie = User.Cookie, //字符串Cookie     可选项   
                Timeout = 100000, //连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                //用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                Allowautoredirect = true, //是否根据301跳转     可选项   
            };
            return http.GetHtml(itemPost).Html;
        }

        /// <summary>
        /// 登录51cto
        /// </summary>
        /// <param name="tid"></param>
        /// <returns></returns>
        public static string Login(string email,string password,string autologin= "on")
        {
            var http = new HttpHelper();
            var itemPost = new HttpItem
            {
                URL = "http://home.51cto.com/index.php?s=%2FIndex%2FdoLogin", //URL     必需项    
                Method = "POST", //URL     可选项 默认为Get   
                IsToLower = false,
                Postdata = "email=" + HttpUtility.UrlEncode(email, Encoding.UTF8) + "&passwd=" + password + "&autologin="+autologin+"&reback=http%253A%252F%252Fbbs.51cto.com&button.x=31&button.y=15",
                Timeout = 100000, //连接超时时间     可选项默认为100000    
                ReadWriteTimeout = 30000, //写入Post数据超时时间     可选项默认为30000   
                UserAgent = "Mozilla/5.0 (Windows NT 5.2; rv:21.0) Gecko/20100101 Firefox/21.0",
                //用户的浏览器类型，版本，操作系统     可选项有默认值   
                ContentType = "application/x-www-form-urlencoded; charset=UTF-8", //返回类型    可选项有默认值   
                Allowautoredirect = true, //是否根据301跳转     可选项   
            };
            return http.GetHtml(itemPost).Html;
        }

    }
}
