using Gkg.Core.Services;
using Gkg.View.MainPage;
using Gkg.ViewModel.MainPage;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;


namespace Gkg.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public IServiceProvider Services { get; private set; }
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var serviceProvider = new ServiceCollection()
                .AddSingleton<TitleBar>()
                .AddSingleton<TitleBarViewModel>()
                .AddSingleton<MainWindowViewModel>()
                .AddSingleton<ITitleService,GkgTitleService>()
                .BuildServiceProvider();
            Services = serviceProvider;
            CommunityToolkit.Mvvm.DependencyInjection.Ioc.Default.ConfigureServices(serviceProvider);
            var titleBar = Services.GetService<TitleBar>();
            titleBar?.DataContext = Services.GetService<TitleBarViewModel>();
            var mainWindow = new MainWindow() { DataContext = Services.GetService<MainWindowViewModel>(), Content = titleBar };
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
        }
    }

}
