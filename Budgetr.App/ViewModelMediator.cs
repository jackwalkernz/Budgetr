using Budgetr.App.Abstractions;
using Budgetr.App.Types.Notifications;
using Budgetr.App.ViewModels;
using Budgetr.Core.Abstractions;

using System.Windows.Controls;

namespace Budgetr.App
{
    public sealed class ViewModelMediator : IMediator
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly IPageFactory _pageFactory;

        public ViewModelMediator(IViewModelFactory viewModelFactory, IPageFactory pageFactory)
        {
            _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            _pageFactory = pageFactory ?? throw new ArgumentNullException(nameof(pageFactory));
        }

        public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public async Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class
        {
            if (request is PageNavigationNotification changePageNotification)
            {
                MainWindowViewModel mainWindowViewModel = _viewModelFactory.GetViewModel<MainWindowViewModel>();
                mainWindowViewModel.NavigateToPage(changePageNotification.To);
                return HandlePageNavigation(changePageNotification.From, changePageNotification.To) as TResponse;
            }
            if (request is WindowLoadedNotification windowLoaded)
            {
                SplashPageViewModel _splashViewModel = _viewModelFactory.GetViewModel<SplashPageViewModel>();
                await Task.Run(() => _splashViewModel.InitialiseBudgetr());
            }

            throw new NotSupportedException();
        }

        private PageNavigationResponse HandlePageNavigation(Page from, Page to)
        {
            MainWindowViewModel _mainWindowViewModel = _viewModelFactory.GetViewModel<MainWindowViewModel>();
            bool successful = _mainWindowViewModel.NavigateToPage(to);
            return new PageNavigationResponse(successful);
        }
    }
}
