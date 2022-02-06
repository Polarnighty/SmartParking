using SmartParking.Client.BLL.IBLL;
using SmartParking.Client.DAL.IDAL;
using System.Threading.Tasks;

namespace SmartParking.Client.BLL.BLL
{
    public class LoginBLL: ILoginBLL
    {
        ILoginDAL loginDAL;
        public LoginBLL(ILoginDAL loginDAL)
        {
            this.loginDAL = loginDAL;
        }

        public async Task<bool> Lgoin(string userName,string password)
        {
            var loginStr = await loginDAL.Login(userName, password);

            return false;
        }

    }
}
