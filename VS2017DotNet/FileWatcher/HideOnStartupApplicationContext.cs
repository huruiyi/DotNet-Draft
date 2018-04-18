using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
namespace FileWatcher
{
    class HideOnStartupApplicationContext : ApplicationContext
    {
        private Form mainFormInternal;

        // ���캯���������屻�洢��mainFormInternal
        public HideOnStartupApplicationContext(Form mainForm)
        {
            this.mainFormInternal = mainForm;
            this.mainFormInternal.Closed += mainFormInternal_Closed;
        }

        void mainFormInternal_Closed(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
