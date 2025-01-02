using System.Windows.Controls;

namespace Budgetr.App.Abstractions
{
    public interface IPageFactory
    {
        TPage GetPage<TPage>() where TPage : Page;
    }
}
