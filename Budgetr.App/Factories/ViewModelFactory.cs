using Budgetr.App.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Serilog;

namespace Budgetr.App.Factories
{
    public class ViewModelFactory : IViewModelFactory
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger _logger;

        public ViewModelFactory(IServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TViewModel GetViewModel<TViewModel>() where TViewModel : ViewModelBase => _serviceProvider.GetRequiredService<TViewModel>() ?? throw new Exception($"Could not create ViewModel of type {typeof(TViewModel).Name}");
    }
}
