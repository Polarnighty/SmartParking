using SmartParking.Client.BLL.IBLL;
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
        public Task<List<UserEntity>> GetAll()
        {
        }
    }
}
