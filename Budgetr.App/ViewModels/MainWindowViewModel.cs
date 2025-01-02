using Budgetr.App.Abstractions;
using Budgetr.Core.Abstractions;

using Serilog;

using System.Windows.Controls;

namespace Budgetr.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigationService;
        public MainWindowViewModel(ILogger logger, INavigationService navigationService, IMediator mediator = null) : base(logger, mediator)
        {
            _navigationService = navigationService;
        }

        public void SetInitialPage()
        {
            _navigationService.NavigateTo<Views.Pages.HomePage>();
        }

        public bool NavigateToPage(Page page)
        {
            _logger.ForContext<MainWindowViewModel>().Debug("Navigating to page {Page}", page.Name);
            try
            {
                _navigationService.NavigateTo(page);
                return true;
            }
            catch (Exception ex)
            {
                _logger.ForContext<MainWindowViewModel>().Error(ex, ex.Message);
                return false;
            }

        }
    }
}
