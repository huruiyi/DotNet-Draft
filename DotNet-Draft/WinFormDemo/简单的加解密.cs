using System;
using System.Windows.Forms;

namespace WinFormDemo
{
    public partial class 简单的加解密 : System.Windows.Forms.Form
    {
        public 简单的加解密()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int P_int_Num, P_int_Key;//定义两个值类型变量
            if (int.TryParse(textBox1.Text, out P_int_Num) && int.TryParse(textBox2.Text, out P_int_Key))
            {
                label4.Text = (P_int_Num ^ P_int_Key).ToString();
            }
            else
            {
                MessageBox.Show("please input the num again.", "error occured");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int P_int_Keys;
            int P_int_Encrypt;
            if (int.TryParse(label4.Text, out P_int_Keys) && int.TryParse(textBox2.Text, out P_int_Encrypt))
            {
                label3.Text = (P_int_Encrypt ^ P_int_Keys).ToString();
            }
            else
            {
                MessageBox.Show("please input again.", "error");
            }
        }
    }
}
