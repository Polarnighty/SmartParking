using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.Entity
{
    public class MenuEntity
    {
        public int MenuId { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }
        public int ParentId { get; set; }
        public string MenuIcon { get; set; }
        public int Index { get; set; }
        public int MenuType { get; set; }

    }
}
