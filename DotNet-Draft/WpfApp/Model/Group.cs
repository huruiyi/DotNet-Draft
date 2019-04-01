using System.Collections.ObjectModel;

namespace WpfApp.Model
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
