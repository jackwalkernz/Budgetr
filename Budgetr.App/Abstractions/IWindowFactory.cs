using System.Windows;

namespace Budgetr.App.Abstractions
{
    internal interface IWindowFactory<TWindow> where TWindow : Window
    {
        TWindow CreateWindow();
    }
}
