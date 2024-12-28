using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class LandingPageViewModel : ViewModelBase
    {
        public LandingPageViewModel(ILogger logger, IMediator mediator = null) : base(logger, mediator)
        {
        }
    }
}
