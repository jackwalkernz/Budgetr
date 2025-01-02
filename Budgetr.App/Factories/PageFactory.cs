using Budgetr.App.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using Serilog;

using System.Windows.Controls;

namespace Budgetr.App.Factories
{
    public class PageFactory : IPageFactory
    {
        protected readonly IServiceProvider _serviceProvider;
        protected readonly ILogger _logger;

        public PageFactory(IServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public TPage GetPage<TPage>() where TPage : Page
        {
            _logger.ForContext<PageFactory>().Debug("Creating page");
            return _serviceProvider.GetRequiredService<TPage>();
        }
    }
}
