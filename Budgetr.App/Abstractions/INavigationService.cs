using System.Windows.Controls;

namespace Budgetr.App.Abstractions
{
    public interface INavigationService
    {
        void NavigateTo<TPage>() where TPage : Page, new();
        void NavigateTo(Page page);
        void GoBack();
    }
}
