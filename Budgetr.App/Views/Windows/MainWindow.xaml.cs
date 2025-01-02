using Budgetr.App.Abstractions;
using Budgetr.App.Types.Notifications;
using Budgetr.App.ViewModels;
using Budgetr.Core.Abstractions;

using Serilog;

using System.Windows;
using System.Windows.Controls;

namespace Budgetr.App.Views.Windows
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ILogger _logger;
        private readonly IViewModelFactory _viewModelFactory;
        private readonly MainWindowViewModel _viewModel;
        private readonly IFrameFactory _frameFactory;
        private readonly IMediator _mediator;
        public MainWindow(IViewModelFactory viewModelFactory, ILogger logger, IFrameFactory frameFactory, IMediator mediator) : base()
        {
            InitializeComponent();

            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _viewModelFactory = viewModelFactory ?? throw new ArgumentNullException(nameof(viewModelFactory));
            _frameFactory = frameFactory ?? throw new ArgumentNullException(nameof(frameFactory));
            _viewModel = viewModelFactory.GetViewModel<MainWindowViewModel>() ?? throw new ArgumentNullException(nameof(viewModelFactory));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            MainFrame = _frameFactory.GetFrame<Frame>();
            DataContext = _viewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                try
                {
                    _mediator.Send<WindowLoadedNotification, WindowLoadedResponse>(new WindowLoadedNotification(), cts.Token);
                }
                catch (Exception ex)
                {
                    _logger.Error(ex, "An error occurred while loading the window.");
                }
            }
        }
    }
}