using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFGroup
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Group> GroupLst = new ObservableCollection<Group>();
        
        public MainWindow()
        {
            
            InitializeComponent();

            Init();
            //listView.DataContext = GroupLst;
        }

        private void Init()
        {
            for (int i = 0; i < 8; i++)
            {
                Group gp = new Group();
                gp.yhukou = "由户口" + i;
                gp.zhukou = "至户口" + i;
                gp.GroupItemLst = new ObservableCollection<GroupItem>();
                for (int j = 0; j < 2; j++)
                {
                    GroupItem gpItem = new GroupItem();
                    gpItem.cName = "中文" + j;
                    gp.GroupItemLst.Add(gpItem);
                }
                GroupLst.Add(gp);
            }
        }
    }
}
