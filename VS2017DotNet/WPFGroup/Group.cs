using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFGroup
{
    public class Group
    {
        public string yhukou { get; set; }
        public string zhukou { get; set; }
        public ObservableCollection<GroupItem> GroupItemLst { get; set; }
    }

    public class GroupItem
    {
        public string cName { get; set; }
        public string eName { get; set; }
    }
}
