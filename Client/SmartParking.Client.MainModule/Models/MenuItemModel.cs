using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SmartParking.Client.MainModule.Models
{
    public class MenuItemModel : BindableBase
    {
        public string MenuIcon { get; set; }
        public string MenuHeader { get; set; }
        public string TargetView { get; set; }
        private bool _isExpanded;
        public bool IsExpanded
        {
            get { return _isExpanded; }
            set { SetProperty(ref _isExpanded, value); }
        }
        public List<MenuItemModel> Children { get; set; }

        public ICommand OpenViewCommand
        {
            get => new DelegateCommand(() =>
            {
                if ((Children == null || Children.Count == 0) && !string.IsNullOrEmpty(TargetView))
                {
                    //页面跳转
                    regionManager.RequestNavigate("MainCententRegion", TargetView);
                }
                else
                {
                    IsExpanded = !IsExpanded;
                }
            });
        }

        IRegionManager regionManager = null;
        public MenuItemModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

    }
}
