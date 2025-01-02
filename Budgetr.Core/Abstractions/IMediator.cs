using System.Threading;
using System.Threading.Tasks;

namespace Budgetr.Core.Abstractions
{
    public interface IMediator
    {
        Task<TResponse> Send<TRequest, TResponse>(TRequest request, CancellationToken cancellationToken = default) where TRequest : class where TResponse : class;

        Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = default);
    }
}
