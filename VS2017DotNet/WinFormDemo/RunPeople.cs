using System;
using System.Drawing;
using System.Windows.Forms;
using WinFormDemo.Properties;

namespace WFA_04
{
    public partial class RunPeople : Form
    {
        private Random r = new Random();
        private Bitmap[] pics_Shang = { Resources.Role1_01, Resources.Role1_02, Resources.Role1_03, Resources.Role1_04, Resources.Role1_05, Resources.Role1_06 };
        private Bitmap[] pics_Xia = { Resources.Role1_07, Resources.Role1_08, Resources.Role1_09, Resources.Role1_10, Resources.Role1_11, Resources.Role1_12 };
        private Bitmap[] pics_Zuo = { Resources.Role1_13, Resources.Role1_14, Resources.Role1_15, Resources.Role1_16, Resources.Role1_17, Resources.Role1_18 };
        private Bitmap[] pics_You = { Resources.Role1_19, Resources.Role1_20, Resources.Role1_21, Resources.Role1_22, Resources.Role1_23, Resources.Role1_24 };
        private int count = 0;

        public RunPeople()
        {
            InitializeComponent();
        }

        //顺着走
        private void timer1_Tick(object sender, EventArgs e)
        {
            //余数为零行往右走
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Left++;
                //如果碰到边缘，那么就走向下一行
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Left = (panel1.Width - pcbImage.Width);
                    pcbImage.Top++;
                }
            }
            //余数为1行往左走
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Left--;
                //如果碰到边缘，那么就走向下一行
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Left = 0;
                    pcbImage.Top++;
                }
            }
            //如果走到右下角，顺着走的时间（timer1）停止，此时逆着走的时间（ timer3）开始
            if (pcbImage.Top / 64 == 4 && pcbImage.Left == (panel1.Width - pcbImage.Width))
            {
                timer1.Enabled = false;
                timer2.Enabled = false;//控制切换图片的时间
                timer3.Enabled = true;
                timer4.Enabled = true;//控制切换图片的时间
            }
        }

        //逆着走
        private void timer3_Tick(object sender, EventArgs e)
        {
            //余数为0往右走
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Left++;
                //如果碰到边缘，那么就走向上一行
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Left = panel1.Width - pcbImage.Width;
                    pcbImage.Top--;
                }
            }
            //余数为1往左走
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Left--;
                //如果碰到边缘，那么就走向上一行
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Left = 0;
                    pcbImage.Top--;
                }
            }

            //如果走到右上角，逆着走的时间停止，向左走一行的时间（ timer5）开始
            if ((pcbImage.Top) / 2 == 0)
            {
                timer3.Enabled = false;
                timer4.Enabled = false;//控制切换图片的时间
                timer5.Enabled = true;
                timer6.Enabled = true;//控制切换图片的时间
            }
        }

        //向左走一行
        private void timer5_Tick(object sender, EventArgs e)
        {
            pcbImage.Left--;
            //如果碰到边缘，那么向左走一行的时间停止（timer5）顺着走的时间（timer1）开始
            if (pcbImage.Left / 2 == 0)
            {
                timer1.Enabled = true;
                timer2.Enabled = true;//控制切换图片的时间
                timer5.Enabled = false;
                timer6.Enabled = false;//控制切换图片的时间

                lblX.Text = pcbImage.Left.ToString();
                lblY.Text = pcbImage.Top.ToString();
            }
        }

        //顺走时候的图片切换
        private void timer2_Tick(object sender, EventArgs e)
        {
            //余数为0往右走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Image = pics_You[count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left >= (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Image = pics_Xia[count++ % 6];
                }
            }
            //余数为1往左走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Image = pics_Zuo[count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left == 0)
                {
                    pcbImage.Image = pics_Xia[count++ % 6];
                }
            }
            lblX.Text = pcbImage.Left.ToString();
            lblY.Text = pcbImage.Top.ToString();
        }

        ////逆走时候的图片切换
        private void timer4_Tick(object sender, EventArgs e)
        {
            lblX.Text = pcbImage.Left.ToString();
            lblY.Text = pcbImage.Top.ToString();
            //余数为0往右走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 0)
            {
                pcbImage.Image = pics_You[count++ % 6];
                if (pcbImage.Left == (panel1.Width - pcbImage.Width))
                {
                    pcbImage.Image = pics_Shang[count++ % 6];
                }
            }
            //余数为1往左走时候切换的图片
            if ((pcbImage.Top / 64) % 2 == 1)
            {
                pcbImage.Image = pics_Zuo[count++ % 6];
                //如果碰到边缘，那么就切换向下走的图片
                if (pcbImage.Left <= 0)
                {
                    pcbImage.Image = pics_Shang[count++ % 6];
                }
            }
        }

        //向左走一行的图片
        private void timer6_Tick(object sender, EventArgs e)
        {
            pcbImage.Image = pics_Zuo[count++ % 6];
        }
    }
}
