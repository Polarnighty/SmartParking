using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using SmartParking.Client.BLL.BLL;
using SmartParking.Client.BLL.IBLL;
using SmartParking.Client.DAL.DAL;
using SmartParking.Client.DAL.IDAL;
using SmartParking.Client.Start.Views;
using System.Windows;
using SmartParking.Client.MainModule;
using SmartParking.Client.BaseModule;
using System.Windows.Threading;

namespace SmartParking.Client.Start
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void InitializeShell(Window shell)
        {
            if (Container.Resolve<LoginView>().ShowDialog() == false)
            {
                Current?.Shutdown();
            }
            else
                base.InitializeShell(shell);
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<Dispatcher>(() => Current.Dispatcher);

            containerRegistry.Register<ILoginDAL, LoginDAL>();
            containerRegistry.Register<IUserDAL, UserDAL>();

            containerRegistry.Register<ILoginBLL, LoginBLL>();
            containerRegistry.Register<IUserBLL, UserBLL>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            //可以改为自动扫描
            moduleCatalog.AddModule<MainModule.MainModule>();
            moduleCatalog.AddModule<BaseInfoModule>();
        }
    }
}
