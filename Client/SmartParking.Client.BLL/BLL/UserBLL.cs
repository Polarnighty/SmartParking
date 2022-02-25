using Newtonsoft.Json;
using SmartParking.Client.BLL.IBLL;
using SmartParking.Client.DAL.IDAL;
using SmartParking.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL.BLL
{
    public class UserBLL : IUserBLL
    {
        IUserDAL userDAL;
        public UserBLL(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }

        public async Task<List<UserEntity>> GetAll()
        {
            var usersStr = await userDAL.GetAll();
            return JsonConvert.DeserializeObject<List<UserEntity>>(usersStr);
        }


        public async Task<List<RoleEntity>> GetRolesByUserId(int uid)
        {
            var roleStr = await userDAL.GetRolesByUserId(uid);
            return JsonConvert.DeserializeObject<List<RoleEntity>>(roleStr);
        }

        public async Task ResetPassword(int uid)
        {
            return;
        }
    }
}
