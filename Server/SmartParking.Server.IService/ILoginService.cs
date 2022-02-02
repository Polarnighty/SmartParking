using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IService
{
    public interface ILoginService : IBaseService
    {
        public void Get(string username, string pwd);
    }
}
