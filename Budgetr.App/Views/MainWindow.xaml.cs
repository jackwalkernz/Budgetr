using Budgetr.App.ViewModels;
using Budgetr.App.Views.Pages;

using Serilog;

using System.Windows;

namespace Budgetr.App.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILogger? _logger;
        private MainWindowViewModel? _viewModel;
        private LandingPage? _initialPage;
        public MainWindow() : base()
        {
            InitializeComponent();
            _logger = null;
            _viewModel = null;
            _initialPage = new LandingPage();
            MainFrame.Navigate(_initialPage);
        }

        public void SetServices(ILogger logger, MainWindowViewModel viewModel, LandingPageViewModel pageViewModel)
        {
            _logger = logger;
            _viewModel = viewModel;
            _initialPage?.SetServices(pageViewModel);
        }
    }
}