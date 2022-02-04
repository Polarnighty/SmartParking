using Prism.Commands;
using Prism.Mvvm;
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

        public string UserName
        {
            get { return userName; }
            set { SetProperty<string>(ref userName, value); }
        }


        private string password;

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

            }
            catch (Exception ex)
            {

            }
        }
    }
}