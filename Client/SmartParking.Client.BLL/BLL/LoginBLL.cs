using Newtonsoft.Json;
using SmartParking.Client.BLL.IBLL;
using SmartParking.Client.DAL.IDAL;
using SmartParking.Client.Entity;
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
            //反序列化用户信息
            var userEntity = JsonConvert.DeserializeObject<UserEntity>(loginStr);

            if (userEntity!=null)
            {
                GlobalEntity.CurrentUserInfo = userEntity;
                return true;
            }
            return false;
        }

    }
}
