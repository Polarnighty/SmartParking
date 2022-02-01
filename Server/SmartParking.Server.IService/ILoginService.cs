using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.IService
{
    public interface ILoginService
    {
        public void Get(string un, string pwd);
    }
}
