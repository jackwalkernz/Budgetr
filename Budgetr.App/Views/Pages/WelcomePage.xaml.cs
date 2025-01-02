using Budgetr.App.Abstractions;
using Budgetr.App.ViewModels;

using System.Windows.Controls;

namespace Budgetr.App.Views.Pages
{
    /// <summary>
    /// Interaction logic for WelcomePage.xaml
    /// </summary>
    public partial class WelcomePage : Page
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly WelcomePageViewModel _viewModel;
        public WelcomePage(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            _viewModelFactory = viewModelFactory;
            _viewModel = _viewModelFactory.GetViewModel<WelcomePageViewModel>();
            DataContext = _viewModel;
        }
    }
}
