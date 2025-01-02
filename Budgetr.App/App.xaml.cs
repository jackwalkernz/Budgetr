using Budgetr.App.Abstractions;
using Budgetr.App.Factories;
using Budgetr.App.Services;
using Budgetr.App.ViewModels;
using Budgetr.App.Views.Pages;
using Budgetr.App.Views.Windows;
using Budgetr.Core.Abstractions;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Serilog;
using Serilog.Formatting.Compact;

using System.Windows;
using System.Windows.Controls;

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
                .WriteTo.File(new CompactJsonFormatter(), "logs/log.txt", Serilog.Events.LogEventLevel.Verbose, rollingInterval: RollingInterval.Day)
                .WriteTo.Debug(Serilog.Events.LogEventLevel.Verbose)
                .CreateLogger();
            _host = Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    services.AddSerilog(logger);
                    services.AddSingleton<MainWindow>();
                    services.AddSingleton<Frame>();
                    services.AddSingleton<MainWindowViewModel>();
                    services.AddSingleton<ViewModelMediator>();
                    services.AddTransient<HomePage>();
                    services.AddSingleton<LandingPageViewModel>();
                    services.AddTransient<SplashPage>();
                    services.AddSingleton<SplashPageViewModel>();
                    services.AddSingleton<WelcomePageViewModel>();
                    services.AddTransient<WelcomePage>();
                    services.AddSingleton<IPageFactory, PageFactory>();
                    services.AddSingleton<IViewModelFactory, ViewModelFactory>();
                    services.AddSingleton<IFrameFactory, FrameFactory>();
                    services.AddSingleton<INavigationService, NavigationService>((sp) =>
                    {
                        MainWindow window = (MainWindow)Application.Current.MainWindow;
                        Frame mainFrame = window.MainFrame;
                        ILogger logger = sp.GetRequiredService<ILogger>();
                        IPageFactory pageFactory = sp.GetRequiredService<IPageFactory>();
                        return new NavigationService(mainFrame.NavigationService, logger, pageFactory);
                    });
                    services.AddSingleton<IMediator, ViewModelMediator>();
                })
                .Build();
        }

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            await _host.StartAsync();
            ILogger logger = _host.Services.GetRequiredService<ILogger>();
            logger.ForContext<App>().Information("Application started");
            IViewModelFactory _viewModelFactory = _host.Services.GetRequiredService<IViewModelFactory>();
            IFrameFactory frameFactory = _host.Services.GetRequiredService<IFrameFactory>();
            IMediator mediator = _host.Services.GetRequiredService<IMediator>();
            IPageFactory pageFactory = _host.Services.GetRequiredService<IPageFactory>();
            MainWindow window = new MainWindow(_viewModelFactory, logger, frameFactory, mediator, pageFactory);
            INavigationService navigationService = _host.Services.GetRequiredService<INavigationService>();
            HomePage page = _host.Services.GetRequiredService<HomePage>();
            navigationService.NavigateTo(page);
            window.Show();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            await _host.StopAsync();
            _host.Dispose();
            base.OnExit(e);
        }
    }
}
