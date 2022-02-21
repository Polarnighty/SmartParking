using Prism.Ioc;
using Prism.Mvvm;
using SmartParking.Client.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartParking.Client.MainModule.ViewModels
{
    public class MainHeaderViewModel: BindableBase
    {
        public string CurrentUserName { get; set; }

        public MainHeaderViewModel(IContainerProvider containerProvider)
        {
            if (GlobalEntity.CurrentUserInfo != null)
            {
                CurrentUserName = GlobalEntity.CurrentUserInfo.UserName;
            }
        }

    }
}
