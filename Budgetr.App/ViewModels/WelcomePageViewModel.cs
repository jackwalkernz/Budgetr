using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class WelcomePageViewModel : ViewModelBase
    {
        public WelcomePageViewModel(ILogger logger, IMediator mediator = null) : base(logger, mediator)
        {
        }
    }
}
