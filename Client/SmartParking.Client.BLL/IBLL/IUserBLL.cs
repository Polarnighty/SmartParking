using SmartParking.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL.IBLL
{
    public interface IUserBLL
    {
        Task<List<UserEntity>> GetAll();
        Task<List<RoleEntity>> GetRolesByUserId(int uid);
        Task ResetPassword(int uid);
    }
}
