using System;

namespace Budgetr.Core.Abstractions
{
    public interface IMediator
    {
        void Notify(object sender, EventArgs args);
    }
}
