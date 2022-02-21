using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SmartParking.Client.BaseModule.ViewModels
{
    public class UserManagementViewModel :INavigationAware
    {
        public string PageTitle { get; set; } = "用户信息管理";
        public bool IsCanClose { get; set; } = true;
        private string NavUri { get; set; }
        public DelegateCommand CloseCommand
        {
            get => new DelegateCommand(() =>
            {
                //关闭操作
                //根据URI获取对应的已注册对象名称
                var obj = unityContainer.Registrations.FirstOrDefault(v => v.Name == NavUri);
                var name = obj.MappedToType.Name;
                //根据对象再从Region的Views里面找到对象
                if (!string.IsNullOrEmpty(name))
                {

                }
                //从Region的Views移除该对象
            });
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            throw new NotImplementedException();
        }

        IUnityContainer unityContainer;
        public UserManagementViewModel(IUnityContainer unityContainer)
        {
            this.unityContainer = unityContainer;
        }
    }
}
