using Budgetr.App.Abstractions;
using Budgetr.App.Factories;
using Budgetr.App.Services;
using Budgetr.App.ViewModels;
using Budgetr.App.Views;
using Budgetr.App.Views.Pages;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Formatting.Compact;

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
                .WriteTo.File(new CompactJsonFormatter(), "log.json", Serilog.Events.LogEventLevel.Verbose, rollingInterval: RollingInterval.Day)
                .WriteTo.Debug(Serilog.Events.LogEventLevel.Verbose)
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
                    services.AddTransient<LandingSplash>();
                    services.AddTransient<WelcomePageViewModel>();
                    services.AddTransient<WelcomePage>();
                    services.AddTransient<IPageFactory, PageFactory>();
                    services.AddTransient<INavigationService, NavigationService>(sp =>
                    {
                        ILogger logger = sp.GetRequiredService<ILogger>();
                        MainWindow window = sp.GetRequiredService<MainWindow>();
                        return new NavigationService(window.MainFrame, logger);
                    });
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await _host.StartAsync();
            ILogger logger = _host.Services.GetRequiredService<ILogger>();
            logger.ForContext<App>().Information("Application started");
            LandingSplash splash = _host.Services.GetRequiredService<LandingSplash>();
            splash.Show();
            Task.Run(() =>
            {
                Thread.Sleep(3000);
                Application.Current.Dispatcher.Invoke(() =>
                {
                    MainWindow window = _host.Services.GetRequiredService<IWindowFactory<MainWindow>>().CreateWindow();
                    window.SetServices(logger, _host.Services.GetRequiredService<MainWindowViewModel>(), _host.Services.GetRequiredService<LandingPageViewModel>());
                    window.Show();
                    splash.Close();
                });
            });
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            base.OnExit(e);
            await _host.StopAsync();
            _host.Dispose();
        }
    }
}
