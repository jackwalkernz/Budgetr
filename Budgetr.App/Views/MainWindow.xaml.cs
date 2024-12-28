using Budgetr.App.ViewModels;

using Serilog;

using System.Windows;

namespace Budgetr.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ILogger _logger;
        private MainWindowViewModel _viewModel;
        public MainWindow() : base()
        {
            InitializeComponent();
            _logger = null;
            _viewModel = null;
        }

        public void SetServices(ILogger logger, MainWindowViewModel viewModel)
        {
            _logger = logger;
            _viewModel = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}