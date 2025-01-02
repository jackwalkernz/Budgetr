using System.Windows.Controls;

namespace Budgetr.App.Abstractions
{
    public interface IFrameFactory
    {
        TFrame GetFrame<TFrame>() where TFrame : Frame;
    }
}
