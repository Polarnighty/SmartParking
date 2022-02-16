using SmartParking.Server.EFCore;
using SmartParking.Server.IService;
using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Service
{
    public class MenuService : BaseService, IMenuService
    {
        public MenuService(IEFContext eFContext):base(eFContext)
        {
        }

        public List<MenuInfo> GetAllMenus()
        {
            throw new NotImplementedException();
        }

        public List<MenuInfo> GetMenuByRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public List<MenuInfo> GetMenuByUserId(int userId)
        {
            throw new NotImplementedException();
        }

        public void SaveMenu(string data)
        {
            throw new NotImplementedException();
        }
    }
}
