using System;
using System.Collections.Generic;
using System.Text;

namespace SingCn.Common.Helper
{
    public class ToolHelper
    {

        /// <summary>
        /// 时间转成Unix时间戳
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long UNIX_TIMESTAMP(DateTime dateTime)
        {
            return (dateTime.Ticks - DateTime.Parse("1970-01-01 00:00:00").Ticks) / 10000;
        }
    }
}
