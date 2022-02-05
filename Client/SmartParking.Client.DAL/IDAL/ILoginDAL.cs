using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL.IDAL
{
    public interface ILoginDAL
    {
        public Task<String> Login(string userName, string password);
    }
}
