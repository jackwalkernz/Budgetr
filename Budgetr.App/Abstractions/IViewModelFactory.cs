namespace Budgetr.App.Abstractions
{
    public interface IViewModelFactory
    {
        TViewModel GetViewModel<TViewModel>() where TViewModel : ViewModelBase;
    }
}
