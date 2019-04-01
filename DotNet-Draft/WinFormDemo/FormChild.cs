using System;
using System.Windows.Forms;
using WinFormDemo.Services;

namespace WinFormDemo
{
    public partial class FormChild : Form, IAfterText
    {
        public FormChild()
        {
            InitializeComponent();
        }

        public void SetText(string text)
        {
            this.txtMsg.Text = text;
        }

        public void AfterRecieveData(object sender, EventArgs e)
        {
            SendTextEventArgs ev = (SendTextEventArgs)e;
            this.txtMsg.Text = ev.Text;
        }

        public void AfterTextChanger(string text)
        {
            this.txtMsg.Text = text;
        }
    }
}
