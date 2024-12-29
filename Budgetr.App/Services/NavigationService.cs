using Budgetr.App.Abstractions;

using Serilog;

using System.Windows.Controls;

namespace Budgetr.App.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Frame _frame;
        private readonly ILogger _logger;

        public NavigationService(Frame frame, ILogger logger)
        {
            _frame = frame;
            _logger = logger;
        }

        public void GoBack()
        {
            if (!_frame.NavigationService.CanGoBack)
                _logger.ForContext<NavigationService>().Warning("You cannot go back");
            else
            {
                _frame.NavigationService.GoBack();
            }
        }

        public void NavigateTo<TPage>() where TPage : Page, new()
        {
            _frame.Navigate(new TPage());
        }

        public void NavigateTo(Page page)
        {
            _frame.Navigate(page);
        }
    }
}
