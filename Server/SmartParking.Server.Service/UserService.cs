using Microsoft.EntityFrameworkCore;
using SmartParking.Server.EFCore;
using SmartParking.Server.IService;
using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Service
{
    public class UserService : BaseService,IUserService
    {
        public UserService(IEFContext eFContext):base(eFContext)
        {
        }

        public List<RoleInfo> GetRolesByUserId(int uid)
        {
            return context.Set<SysUserInfo>().Where(u => u.UserId == uid).Include(u => u.RoleInfos)
                .Select(u => u.RoleInfos).FirstOrDefault();
        }
    }
}
