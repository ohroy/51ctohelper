using System;
using System.Windows.Forms;
using SingCn.Ex51cto.Deal;
using System.Drawing;
using System.Threading;
using SingCn.Windows.Forms;

namespace SingCn.Ex51cto.UI
{
    public partial class FormMain : QQForm
    {
        public FormMain()
        {
            InitializeComponent();
        }



        private void Form1_Load(object sender, EventArgs e)
        {
            DoLog.OutMsg(RtbLog, "程序启动成功，欢迎使用@刘小博啊啊开发的51cto用户助手。", Color.Green);
            DoLog.OutMsg(RtbLog, "目前，刷访问因为太恶劣，此功能已下线。", Color.Green);
            DoLog.OutMsg(RtbLog, "送礼物由于免费礼物已经被送完了，暂时送不成功，等待蘑菇添加免费礼物。。", Color.Green);
        }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            var maxPageNum = int.Parse(TxtPageNum.Text);

                var objThread = new Thread(() => DoMain.Go(RtbLog, maxPageNum));
                objThread.Start();
        }

        private void ChkRunType_CheckedChanged(object sender, EventArgs e)
        {
            ShowInTaskbar = !ChkRunType.Checked;
        }

        private void BtnSendGift_Click(object sender, EventArgs e)
        {
            var maxCount = int.Parse(TxtCount.Text);

            var objThread = new Thread(() => DoMain.SendGift(RtbLog, maxCount));
            objThread.Start();
        }

        private void btnNullRe_Click(object sender, EventArgs e)
        {
            var NullId = txtNullId.Text;
            var NullName = txtNullName.Text;
            var NullContent = txtContent.Text;
            DoMain.NullRe(NullName,NullId,NullContent);
            DoLog.OutMsg(RtbLog, "匿名回复操作成功！", Color.Green);
        }

        private void btnStartTest_Click(object sender, EventArgs e)
        {
            var objThread = new Thread(() => DoMain.AutoTest(RtbLog));
            objThread.Start();
        }

        private void btnFav_Click(object sender, EventArgs e)
        {
            var startTid = int.Parse(txtStartTid.Text);
            var endTid = int.Parse(txtEndTid.Text);
            var objThread = new Thread(() => DoMain.Fav(RtbLog,startTid,endTid));
            objThread.Start();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var objThread = new Thread(() => DoMain.TryLogin(RtbLog));
            objThread.Start();
        }

        private void btnStartRush_Click(object sender, EventArgs e)
        {
            var start = int.Parse(TxtRushStart.Text);
            var end = int.Parse(TxtRushEnd.Text);
            var userid =TxtUserid.Text;
            var count = int.Parse(TxtRushCount.Text);
            var objThread = new Thread(() => DoMain.DoRush(RtbLog,start,end,userid,count));
            objThread.Start();
        }

        private void BtnCoinStart_Click(object sender, EventArgs e)
        {
            var userid = TxtCoinUserid.Text;
            var count = int.Parse(TxtCoinCount.Text);
            var objThread = new Thread(() => DoMain.DoCoin(RtbLog,userid, count));
            objThread.Start();
        }


    }
}
