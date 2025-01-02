using Budgetr.App.Abstractions;
using Budgetr.App.Views.Pages;
using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class SplashPageViewModel : ViewModelBase
    {
        private IPageFactory _pageFactory;
        private SplashPage _page;
        public SplashPageViewModel(ILogger logger, IMediator mediator = null, IPageFactory pageFactory = null) : base(logger, mediator)
        {
            _pageFactory = pageFactory;
            _page = _pageFactory.GetPage<SplashPage>() ?? throw new ArgumentNullException(nameof(pageFactory));
        }

        public Task InitialiseBudgetr()
        {
            Thread.Sleep(3000);
            return Task.CompletedTask;
        }
    }
}
