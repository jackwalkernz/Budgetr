using Budgetr.App.Abstractions;

using Microsoft.Extensions.DependencyInjection;

using System.Windows.Controls;

namespace Budgetr.App.Factories
{
    public class FrameFactory : IFrameFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public FrameFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        }

        public TFrame GetFrame<TFrame>() where TFrame : Frame => _serviceProvider.GetRequiredService<TFrame>();
    }
}
