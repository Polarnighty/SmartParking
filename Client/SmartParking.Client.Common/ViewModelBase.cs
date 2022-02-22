using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace SmartParking.Client.Common
{
    public abstract class ViewModelBase : INavigationAware
    {
        // *  未保存
        public string PageTitle { get; set; } = "标签标题";
        public bool IsCanClose { get; set; } = true;

        private string NavUri { get; set; }
        public DelegateCommand CloseCommand
        {
            get => new DelegateCommand(() =>
            {
                // 关闭操作
                // 根据URI获取对应的已注册对象名称
                var obj = _unityContainer.Registrations.FirstOrDefault(v => v.Name == NavUri);
                string name = obj.MappedToType.Name;
                // 根据对象名称再从Region的Views里面找到对象
                if (!string.IsNullOrEmpty(name))
                {
                    var region = _regionManager.Regions["MainContentRegion"];
                    var view = region.Views.FirstOrDefault(v => v.GetType().Name == name);
                    // 把这个对象从Region的Views里移除
                    if (view != null)
                    {
                        region.Remove(view);
                    }
                }
            });
        }

        public DelegateCommand RefreshCommand { get => new DelegateCommand(Refresh); }
        public DelegateCommand AddCommand { get => new DelegateCommand(AddItem); }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavUri = navigationContext.Uri.ToString();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {

        }


        IUnityContainer _unityContainer;
        IRegionManager _regionManager;
        public ViewModelBase(IUnityContainer unityContainer, IRegionManager regionManager)
        {
            _unityContainer = unityContainer;
            _regionManager = regionManager;
        }

        public virtual void Refresh() { 
            
        }

        public virtual void AddItem() { }
    }
}
