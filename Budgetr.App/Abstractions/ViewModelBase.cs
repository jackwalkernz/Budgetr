using Budgetr.Core.Abstractions;

using Serilog;

namespace Budgetr.App.Abstractions
{
    public class ViewModelBase
    {
        protected IMediator _mediator;
        protected ILogger _logger;
        protected ViewModelBase(ILogger logger, IMediator mediator = null)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public void SetMediator(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
