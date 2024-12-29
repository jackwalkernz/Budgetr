using System.Windows.Controls;

namespace Budgetr.App.Abstractions
{
    public interface IPageFactory
    {
        Page GetPage<TPage>(string pageName) where TPage : Page;
    }
}
