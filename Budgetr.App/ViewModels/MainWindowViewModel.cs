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

        public void SetPage(Page page)
        {
            _navigationService.NavigateTo(page);
        }
    }
}
