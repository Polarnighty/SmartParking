using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL.IDAL
{
    public interface IUserDAL
    {
        public Task<string> GetAll();
        public Task<string> GetRolesByUserId(int uid);

    }
}
