using System.IO;
using System.Windows.Forms;

namespace WfApp
{
    public partial class USB监控 : Form
    {
        public USB监控()
        {
            InitializeComponent();
        }

        public const int WM_DEVICECHANGE = 0x219;//U盘插入后，OS的底层会自动检测到，然后向应用程序发送“硬件设备状态改变“的消息
        public const int DBT_DEVICEARRIVAL = 0x8000;  //就是用来表示U盘可用的。一个设备或媒体已被插入一块，现在可用。
        public const int DBT_DEVICEREMOVECOMPLETE = 0x8004;  //一个设备或媒体片已被删除。

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                switch (m.WParam.ToInt32())
                {
                    case DBT_DEVICEARRIVAL://U盘插入
                        DriveInfo[] uin = DriveInfo.GetDrives();
                        foreach (DriveInfo drive in uin)
                        {
                            if (drive.DriveType == DriveType.Removable)
                            {
                                this.Text = "U盘已插入，盘符为:" + drive.Name.ToString();
                                break;
                            }
                        }
                        break;

                    case DBT_DEVICEREMOVECOMPLETE: //U盘卸载
                        this.Text = "U盘被拔出！";
                        break;

                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }
    }
}