using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel(ILogger logger, IMediator mediator = null) : base(logger, mediator)
        {
        }
    }
}
