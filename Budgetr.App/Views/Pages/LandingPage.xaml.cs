using Budgetr.App.ViewModels;

using System.Windows;
using System.Windows.Controls;

namespace Budgetr.App.Views.Pages
{
    /// <summary>
    /// Interaction logic for LandingPage.xaml
    /// </summary>
    public partial class LandingPage : Page
    {
        private LandingPageViewModel? _viewModel;
        public LandingPage()
        {
            InitializeComponent();
        }

        public void SetServices(LandingPageViewModel viewModel)
        {
            _viewModel = viewModel;
        }

        private void OnEnterClick(object sender, RoutedEventArgs e)
        {
            _viewModel?.EnterClicked();
        }
    }
}
