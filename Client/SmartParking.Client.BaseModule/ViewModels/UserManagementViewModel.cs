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
using System.Windows.Threading;
using Unity;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel : ViewModelBase
    {
        IUserBLL userBLL;
        IUnityContainer unityContainer;
        public ObservableCollection<UserModel> UserList { get; set; }= new ObservableCollection<UserModel>();
        public UserManagementViewModel(IUnityContainer unityContainer, IRegionManager regionManager, IUserBLL userBLL) :base(unityContainer, regionManager)
        {
            this.unityContainer = unityContainer;
            this.userBLL = userBLL;
            PageTitle = "系统用户管理";
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
                    UserIcon = "",
                    Age = item.Age,
                    Password = item.Password,
                    RealName = item.RealName
                };
                //用户角色
                var roles = userBLL.GetRolesByUserId(userModel.UserId).GetAwaiter().GetResult();
                //填充
                roles?.ForEach(r => userModel.Roles.Add(new RoleModel {
                    RoleId = r.RoleId,
                    RoleName = r.RoleName,
                    State = r.State
                }));
                // 编辑
                userModel.EditCommand = new DelegateCommand<object>(EditItem);
                // 删除
                userModel.DeleteCommand = new DelegateCommand<object>(DeleteItem);
                // 角色分配
                userModel.RoleCommand = new DelegateCommand<object>(SetRoles);
                // 重置密码
                userModel.PwdCommand = new DelegateCommand<object>(SetPassword);

                unityContainer.Resolve<Dispatcher>().Invoke(() => {
                    UserList.Add(userModel);
                });
                    
                }
            });
        }
        public override void AddItem()
        {
        }
        private void EditItem(object obj)
        {

        }
        private void DeleteItem(object obj)
        {

        }
        private void SetRoles(object obj)
        {

        }
        private void SetPassword(object obj)
        {
            Task.Run(async ()=> {
                await userBLL.ResetPassword(int.Parse(obj.ToString()));
                System.Windows.MessageBox.Show("密码已重置","提示");
            });
        }
    }
}
