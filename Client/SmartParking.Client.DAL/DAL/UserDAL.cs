using SmartParking.Client.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL.DAL
{
    public class UserDAL : WebDataAcess, IUserDAL
    {
        public Task<string> GetAll()
        {
            // 服务接口
            return GetDatas($"user/all");
        }

        public Task<string> GetRolesByUserId(int uid)
        {
            return GetDatas($"user/roles/{uid}");
        }
    }
}
