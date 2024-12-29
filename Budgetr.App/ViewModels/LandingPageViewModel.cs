using Budgetr.App.Events;
using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        public LandingPageViewModel(ILogger logger, IMediator mediator = null) : base(logger, mediator)
        {
        }

        public void EnterClicked()
        {
            _logger.ForContext<LandingPageViewModel>().Debug("Enter button clicked");
            _mediator.Notify(this, new LandingPageEventArgs());
        }
    }
}
