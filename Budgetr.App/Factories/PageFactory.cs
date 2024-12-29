using Budgetr.App.Abstractions;
using Budgetr.App.Views.Pages;

using Microsoft.Extensions.DependencyInjection;

using Serilog;

using System.Windows.Controls;

namespace Budgetr.App.Factories
{
    public class PageFactory : IPageFactory
    {
        protected readonly ServiceProvider _serviceProvider;
        protected readonly ILogger _logger;

        public PageFactory(ServiceProvider serviceProvider, ILogger logger)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public Page GetPage<TPage>(string pageName) where TPage : Page
        {
            switch (pageName)
            {
                case "WelcomePage":
                    return _serviceProvider.GetRequiredService<WelcomePage>();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
