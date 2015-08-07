using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SingCn.Ex51cto.Deal
{
   public class DoLog
    {
        /// <summary>
        /// 委托方式输出信息
        /// </summary>
        /// <param name="rtb">文本框实例</param>
        /// <param name="msg">要输出的信息</param>
        /// <param name="color">信息的颜色</param>
        public static void OutMsg(RichTextBox rtb, string msg, Color color)
        {
            try
            {
                rtb.Invoke(new EventHandler(delegate
                {
                    rtb.SelectionStart = rtb.Text.Length;
                    rtb.SelectionColor = color;
                    rtb.AppendText(msg + "\r\n");
                    rtb.ScrollToCaret();
                    if (rtb.Text.Length > 4000)
                    {
                        rtb.Text = string.Empty;
                    }
                }));
            }
            catch (Exception)
            {
                Application.Exit();
            }

        }
    }
}
