using System.Windows;

namespace Budgetr.App.Abstractions
{
    internal interface IWindowFactory
    {
        TWindow GetWindow<TWindow>() where TWindow : Window;
    }
}
