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
            origMenus = GlobalEntity.CurrentUserInfo?.Menus;

            FillMenus(origMenus, 0);

        }

        private void FillMenus(List<MenuEntity> menus,int parentId)
        {
            var sub = origMenus.Where(m => m.ParentId == parentId).OrderBy(m => m.Index);

            if (sub.Count()>0)
            {
                foreach (var item in sub)
                {
                    var mm = new MenuItemModel() { }
                }
            }
        }
    }
}
