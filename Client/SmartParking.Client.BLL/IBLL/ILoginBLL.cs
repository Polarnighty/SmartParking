using SmartParking.Client.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL.IBLL
{
    public interface ILoginBLL
    {
        public Task<bool> Lgoin(string userName, string password);
    }
}
