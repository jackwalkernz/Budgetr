using Budgetr.App.Abstractions;
using Budgetr.App.Events;
using Budgetr.App.ViewModels;
using Budgetr.App.Views.Pages;
using Budgetr.Core.Abstractions;

using System.Windows.Controls;

namespace Budgetr.App
{
    internal sealed class ViewModelMediator : IMediator
    {
        private readonly LandingPageViewModel _landingPageViewModel;
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly IPageFactory _pageFactory;
        public void Notify(object sender, EventArgs args)
        {
            if (sender is LandingPageViewModel)
            {
                if (args is LandingPageEventArgs landingPageArgs)
                {
                    Page page = _pageFactory.GetPage<WelcomePage>("WelcomePage");
                    _mainWindowViewModel.SetPage(page);
                }
            }
        }
    }
}
