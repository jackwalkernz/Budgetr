using Budgetr.App.ViewModels;

using System.Windows.Controls;

namespace Budgetr.App.Views.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        private readonly LandingPageViewModel _viewModel;
        public WelcomePage(LandingPageViewModel viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            DataContext = _viewModel;
        }
    }
}
