using Prism.Ioc;
using Prism.Unity;
using System.Windows;
using WPF.DatabaseContext;
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
        }

        protected override Window CreateShell()
        {
            var w = Container.Resolve<MainWindow>();
            return w;
        }
    }
}
