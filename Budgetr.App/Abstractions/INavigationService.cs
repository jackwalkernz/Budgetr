using System.Windows.Controls;

namespace Budgetr.App.Abstractions
{
    public interface INavigationService
    {
        void NavigateTo<TPage>() where TPage : Page;

        void NavigateTo<TPage>(TPage page) where TPage : Page;
        void GoBack();
    }
}
