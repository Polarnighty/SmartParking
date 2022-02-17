using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
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
        public MenuService(IEFContext eFContext) : base(eFContext)
        {
        }

        public List<MenuInfo> GetAllMenus()
        {
            return context.Set<MenuInfo>().Where(m => m.State == 1).ToList();
        }

        public List<MenuInfo> GetMenuByRoleId(int roleId)
        {
            //获取所有权限
            //var roles = context.Set<RoleInfo>().Where(r => r.RoleId == roleId && r.State == 1).Select(r => r.RoleId).ToList();

            //获取所有权限(可能有BUG)
            return context.Set<RoleInfo>().Where(r => r.RoleId == roleId && r.State == 1).Include(m => m.MenuInfos)
               .Select(r => r.MenuInfos.Where(m => m.State == 1)).FirstOrDefault().Distinct().ToList();
        }

        public List<MenuInfo> GetMenuByUserId(int userId)
        {
            //获取用户权限
            var roles = context.Set<SysUserInfo>().Where(u => u.UserId == userId).Include(u => u.RoleInfos)
                                .Select(u => u.RoleInfos.Where(r => r.State == 1).Select(r => r.RoleId).ToList()).FirstOrDefault();

            //获取菜单(可能有BUG)
            return context.Set<RoleInfo>().Where(r => roles.Contains(r.RoleId)).Include(r => r.MenuInfos)
               .Select(r => r.MenuInfos.Where(m => m.State == 1)).FirstOrDefault().Distinct().ToList();
        }

        public void SaveMenu(string data)
        {
            var value = JsonConvert.DeserializeObject<MenuInfo>(data);

            if (value.MenuId == 0)
            {
                var index = context.Set<MenuInfo>().Max(m=>m.Index);
                value.Index++;
            }
            value.State = 1;

            context.Entry(value).State = value.MenuId == 0 ?
                EntityState.Added : EntityState.Modified;
            context.SaveChanges();

        }
    }
}
