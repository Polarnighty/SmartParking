using SmartParking.Client.DAL.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.DAL.DAL
{
    public class LoginDAL : WebDataAcess, ILoginDAL
    {
        public LoginDAL()
        {

        }
        public Task<string> Login(string userName, string password)
        {
            var contents = new Dictionary<string,HttpContent>();
            contents.Add("userName", new StringContent(userName));
            contents.Add("password", new StringContent(password));
            return PostDatas("User/login", contents);
        }


    }
}
