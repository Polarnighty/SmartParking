using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IService
{
    public interface IMenuService :IBaseService
    {
        List<MenuInfo> GetMenuByUserId(int userId);
        List<MenuInfo> GetMenuByRoleId(int roleId);
        List<MenuInfo> GetAllMenus();
        //包含新增和修改
        void SaveMenu(string data);
    }
}
