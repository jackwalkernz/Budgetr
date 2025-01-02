using Budgetr.App.Abstractions;
using Budgetr.App.ViewModels;

using System.Windows.Controls;

namespace Budgetr.App.Views.Pages
{
    /// <summary>
    /// Interaction logic for SplashPage.xaml
    /// </summary>
    public partial class SplashPage : Page
    {
        private readonly IViewModelFactory _viewModelFactory;
        private readonly SplashPageViewModel _viewModel;
        public SplashPage(IViewModelFactory viewModelFactory)
        {
            InitializeComponent();
            _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            _viewModel = _viewModelFactory.GetViewModel<SplashPageViewModel>() ?? throw new ArgumentNullException(nameof(viewModelFactory));
            DataContext = _viewModel;
        }
    }
}
