using Budgetr.App.Abstractions;
using Budgetr.App.Types.Notifications;
using Budgetr.App.Views.Pages;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        private readonly IPageFactory _pageFactory;
        public LandingPageViewModel(ILogger logger, IPageFactory pageFactory, ViewModelMediator mediator = null) : base(logger, mediator)
        {
            _pageFactory = pageFactory;
        }

        public async void EnterClicked()
        {
            _logger.ForContext<LandingPageViewModel>().Debug("Enter button clicked");
            WelcomePage welcomePage = _pageFactory.GetPage<WelcomePage>();
            LandingPage landingPage = _pageFactory.GetPage<LandingPage>();
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                PageNavigationResponse pageNavigationResponse = await _mediator.Send<PageNavigationNotification, PageNavigationResponse>(new PageNavigationNotification(landingPage, welcomePage), cts.Token);
                if (pageNavigationResponse.IsSuccessful)
                {
                    _logger.ForContext<LandingPageViewModel>().Debug("Successfully navigated to WelcomePage");
                }
                else
                {
                    _logger.ForContext<LandingPageViewModel>().Debug("Failed to navigate to WelcomePage");
                }
            }
        }
    }
}
