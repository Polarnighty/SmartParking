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
        public Task<List<string>> GetAll()
        {
            // 服务接口
            return GetDatas($"{domain}user/all");
        }
    }
}
