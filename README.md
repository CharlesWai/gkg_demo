# A minimal mvvm demo using dependency injection for Gkg

## Open slnx with Visual Studio 2026 or using dotnet sdk to build this solution
```
dotnet build xxx.slnx
```

```csharp
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
```