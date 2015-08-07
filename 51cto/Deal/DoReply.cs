using System;
using System.Collections.Generic;
using System.Text;
using SingCn.Ex51cto.Config;
using System.IO;

namespace SingCn.Ex51cto.Deal
{
  public  class DoReply
    {

      public static List<Reply> GetReplyVo()
      {
          try
          {
              string replys = File.ReadAllText(System.IO.Directory.GetCurrentDirectory() + "\\Config\\reply.txt", Encoding.Default);
              var replyVo = new List<Reply>();
              foreach (string replytext in replys.Split(Environment.NewLine.ToCharArray()))
              {
                  var ry = new Reply {Text = replytext};
                  if (ry.Text != "")
                      replyVo.Add(ry);
              }
              return replyVo;
          }
          catch (Exception ex)
          {
              return null;
          }

      }

    }
}
