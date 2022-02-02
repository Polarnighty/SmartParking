using SmartParking.Server.EFCore;
using SmartParking.Server.IService;
using SmartParking.Server.Models;
using System;
namespace SmartParking.Server.Service
{
    public class LoginService : BaseService, ILoginService
    {
        public LoginService(IEFContext eFContext) :base(eFContext)
        {
        }

        public void Get(string userName, string pwd)
        {
            this.Query<SysUserInfo>(u => u.UserName == userName && u.PassWord == pwd); 
            throw new NotImplementedException();
        }
    }
}
