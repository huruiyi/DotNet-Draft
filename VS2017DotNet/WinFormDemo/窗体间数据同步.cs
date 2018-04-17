using System;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 窗体间数据同步 : Form
    {
        public 窗体间数据同步()
        {
            InitializeComponent();
        }

        public Form1 F1Demo { get; set; }

        public Form2 F2Demo { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            F1Demo = form1;
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (F2Demo != null)
            {
                F2Demo.Show();
            }
            else
            {
                Form2 form2 = new Form2();
                F2Demo = form2;

                //if (F1Demo.SendMsg == null)
                //{
                //    F1Demo.SendMsg = new Action<string>(f.SetText);
                //}
                //else
                //{
                //    //F1Demo.SendMsg -= f.SetText;
                //    //F1Demo.SendMsg += f.SetText;
                //}

                //注册事件响应方法
                F1Demo.AfterSendText += form2.AfterRecieveData;

                F1Demo.F2Demo = form2;

                F1Demo.ListOb.Add(form2);

                //事件触发只能在 类型内部触发。不能在类的外面触发事件。这就是事件的优势。
                //F1Demo.AfterSendText(this, null);

                form2.Show();
            }
        }
    }
}
