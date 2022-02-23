using SmartParking.Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IService
{
    public interface IUserService : IBaseService
    {
        List<RoleInfo> GetRolesByUserId(int uid);
    }
}
