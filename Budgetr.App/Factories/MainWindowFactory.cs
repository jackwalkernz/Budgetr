using Budgetr.App.Abstractions;
using Budgetr.App.Views;

using Microsoft.Extensions.DependencyInjection;

namespace Budgetr.App.Factories
{
    public class MainWindowFactory : IWindowFactory<MainWindow>
    {
        private readonly IServiceProvider _serviceProvider;
        public MainWindowFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public MainWindow CreateWindow()
        {
            return _serviceProvider.GetRequiredService<MainWindow>();
        }
    }
}
