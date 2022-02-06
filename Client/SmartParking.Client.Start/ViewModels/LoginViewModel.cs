using Prism.Commands;
using Prism.Mvvm;
using SmartParking.Client.BLL.BLL;
using SmartParking.Client.BLL.IBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.Start.ViewModels
{
    public class LoginViewModel : BindableBase
    {
        private string userName = "admin";
        private ILoginBLL loginBLL;
        public LoginViewModel(ILoginBLL loginBLL)
        {
            this.loginBLL = loginBLL;
        }
        public string UserName
        {
            get { return userName; }
            set { SetProperty<string>(ref userName, value); }
        }


        private string password="123456";

        public string Password
        {
            get { return password; }
            set { SetProperty<string>(ref password, value); }
        }

        private string errorMsg;

        public string ErrorMsg
        {
            get { return errorMsg; }
            set { SetProperty<string>(ref errorMsg, value); }
        }


        // 登录命令
        public ICommand LoginCommand
        {
            get => new DelegateCommand<object>(OnLogin);
        }
        private void OnLogin(object obj)
        {
            try
            {
                ErrorMsg = "";
                if (string.IsNullOrEmpty(UserName))
                {
                    ErrorMsg = "请输入用户名";
                    return;
                }
                if (string.IsNullOrEmpty(Password))
                {
                    ErrorMsg = "请输入密码";
                    return;
                }
                //登录操作
                if (loginBLL.Lgoin(UserName, Password).GetAwaiter().GetResult())
                {
                    //关闭登录窗口,并且DialogResult返回True

                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}