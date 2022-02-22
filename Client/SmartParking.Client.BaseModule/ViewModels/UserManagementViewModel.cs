using Prism.Commands;
using Prism.Regions;
using SmartParking.Client.BaseModule.Models;
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
        public ObservableCollection<UserModel> UserList { get; set; }
        public UserManagementViewModel(IUnityContainer unityContainer, IRegionManager regionManager) :base(unityContainer, regionManager)
        {
            PageTitle = "系统用户管理";
            UserList = new ObservableCollection<UserModel>();
        }

        public override void Refresh()
        {
            //刷新用户数据
            UserList.Clear();
            Task.Run(()=> 
            { 
                var users = 
            });
        }
    }
}
