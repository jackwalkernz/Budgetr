using Budgetr.App.Abstractions;

using Serilog;

using System.Windows.Controls;

namespace Budgetr.App.Services
{
    public class NavigationService(System.Windows.Navigation.NavigationService navigationService, ILogger logger, IPageFactory pageFactory) : INavigationService
    {
        private readonly System.Windows.Navigation.NavigationService _navigationService = navigationService ?? throw new ArgumentNullException(nameof(navigationService));
        private readonly ILogger _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        private readonly IPageFactory _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));

        public void GoBack()
        {
            if (!_navigationService.CanGoBack)
                _logger.ForContext<NavigationService>().Warning("You cannot go back");
            else
            {
                _navigationService.GoBack();
            }
        }

        public void NavigateTo<TPage>() where TPage : Page
        {
            TPage page = _pageFactory.GetPage<TPage>();
            _logger.ForContext<NavigationService>().Debug("Navigating to page {Page}", typeof(TPage).Name);
            _navigationService.Navigate(page);
        }

        public void NavigateTo<TPage>(TPage page) where TPage : Page
        {
            _logger.ForContext<NavigationService>().Debug("Navigating to page {Page}", typeof(TPage).Name);
            _navigationService.Navigate(page);
        }
    }
}
