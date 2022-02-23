using Prism.Commands;
using Prism.Regions;
using SmartParking.Client.BaseModule.Models;
using SmartParking.Client.BLL.IBLL;
using SmartParking.Client.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        IUserBLL userBLL;
        public ObservableCollection<UserModel> UserList { get; set; }
        public UserManagementViewModel(IUnityContainer unityContainer, IRegionManager regionManager, IUserBLL userBLL) :base(unityContainer, regionManager)
        {
            this.userBLL = userBLL;
            PageTitle = "系统用户管理";
            UserList = new ObservableCollection<UserModel>();
        }

        public override void Refresh()
        {
            //刷新用户数据
            UserList.Clear();
            Task.Run(()=> 
            {
                var users = userBLL.GetAll().GetAwaiter().GetResult();
                foreach (var item in users)
                {
                    var userModel = new UserModel
                    {
                        Index = users.IndexOf(item) + 1,
                        UserId = item.UserId,
                        UserName = item.UserName,
                        //UserIcon = System.Configuration.ConfigurationManager.AppSettings["api_domain"].ToString()
                        //            + item.UserIcon,
                        UserIcon ="",
                        Age = item.Age,
                        Password = item.Password,
                        RealName = item.RealName
                    };
                    //用户角色
                    var roles = userBLL.GetRolesByUserId(userModel.UserId).GetAwaiter().GetResult();
                    //填充
                    roles?.ForEach(r => userModel.Roles.Add(new RoleModel { 
                        RoleId= r.RoleId,
                        RoleName = r.RoleName,
                        State = r.State
                    }));

                    userModel.EditCommand= new DelegateCommand
                    UserList.Add(userModel);
                }
            });
        }
    }
}
