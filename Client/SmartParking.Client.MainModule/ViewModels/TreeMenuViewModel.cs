using SmartParking.Client.Entity;
using SmartParking.Client.MainModule.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.MainModule.ViewModels
{
    public class TreeMenuViewModel
    {
        public List<MenuItemModel> Menus { get; set; } = new List<MenuItemModel>();

        // 列表,没有树型结构
        private List<MenuEntity> origMenus = null;

        public TreeMenuViewModel()
        {
            //获取菜单数据

        }
    }
}
