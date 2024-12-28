using Budgetr.App.Abstractions;
using Budgetr.App.Factories;
using Budgetr.App.Pages;
using Budgetr.App.ViewModels;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;

using System.Windows;

namespace Budgetr.App
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;

        public App()
        {
            ILogger logger = new Serilog.LoggerConfiguration()
                .WriteTo.Console()
                .CreateLogger();
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSerilog(logger);
                    services.AddTransient<MainWindow>();
                    services.AddTransient<LandingPage>();
                    services.AddTransient<ViewModelMediator>();
                    services.AddTransient<IWindowFactory<MainWindow>, MainWindowFactory>();
                    services.AddTransient<MainWindowViewModel>();
                    services.AddTransient<LandingPageViewModel>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await _host.StartAsync();
            ILogger logger = _host.Services.GetRequiredService<ILogger>();
            logger.ForContext<App>().Information("Application started");
            MainWindow window = new MainWindow
            {
                DataContext = _host.Services.GetRequiredService<MainWindowViewModel>(),
                Content = _host.Services.GetRequiredService<LandingPage>()
            };

            MainWindowViewModel mainWindowViewModel = _host.Services.GetRequiredService<MainWindowViewModel>();
            window.SetServices(logger, mainWindowViewModel);

        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}
