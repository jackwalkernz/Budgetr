using Budgetr.App.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using System.Windows;

namespace Budgetr.App.Factories
{
    public class WindowFactory(IServiceProvider serviceProvider) : IWindowFactory
    {
        private readonly IServiceProvider _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

        public TWindow GetWindow<TWindow>() where TWindow : Window => _serviceProvider.GetRequiredService<TWindow>();
    }
}
