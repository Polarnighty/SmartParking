using SmartParking.Server.EFCore;
using SmartParking.Server.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Server.Service
{
    public class UserService : BaseService,IUserService
    {
        public UserService(IEFContext eFContext):base(eFContext)
        {
        }

    }
}
