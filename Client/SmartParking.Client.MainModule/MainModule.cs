using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using SmartParking.Client.MainModule.Views;

namespace SmartParking.Client.MainModule
{
    public class MainModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            //初始化时,添加一个组件到对应的区域
            //例如 左侧菜单
            //需要一个Prims的RegionManger
            var regionManger = containerProvider.Resolve<IRegionManager>();
            regionManger.RegisterViewWithRegion("LeftMenuTreeRegion", typeof(TreeMenuView));
            regionManger.RegisterViewWithRegion("MainHeaderRegion", typeof(MainHeaderView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<TreeMenuView>();
            containerRegistry.Register<MainHeaderView>();
        }

    }
}
