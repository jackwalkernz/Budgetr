using Budgetr.App.Abstractions;
using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class SplashPageViewModel : ViewModelBase
    {
        private readonly IPageFactory _pageFactory;
        public SplashPageViewModel(ILogger logger, IPageFactory pageFactory, IMediator mediator) : base(logger, mediator)
        {
            _pageFactory = pageFactory;
        }
    }
}
