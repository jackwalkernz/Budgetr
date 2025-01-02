using Budgetr.App.Abstractions;
using Budgetr.App.ViewModels;

using System.Windows;
using System.Windows.Controls;
namespace Budgetr.App.Views.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly LandingPageViewModel _viewModel;
        public HomePage(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            _viewModelFactory = viewModelFactory;
            _viewModel = _viewModelFactory.GetViewModel<LandingPageViewModel>();
            DataContext = _viewModel;
        }

        private void OnEnterClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.EnterClicked();
        }

        private void OnNewBudgetClicked(object sender, RoutedEventArgs e)
        {

        }

        private void OnMyBudgetsClicked(object sender, RoutedEventArgs e)
        {

        }
    }
}
