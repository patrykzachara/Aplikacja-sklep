using Prism.Ioc;
using Prism.Modularity;
using Prism.Unity;
using System.Windows;
using WPF.DatabaseContext;
using WPF.Services;
using WPF.Views;

namespace WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            // register other needed services here
            containerRegistry.Register<AppContext>();
            containerRegistry.Register<IShopService, ShopService>();
            containerRegistry.Register<IProductService, ProductService>();

            //Navigation
            containerRegistry.RegisterForNavigation<MainWindow>("MainWindow"); 
            containerRegistry.RegisterForNavigation<AddShopView>("AddShopView");
            containerRegistry.RegisterForNavigation<ProductsView>("ProductsView");
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }
    }
}
