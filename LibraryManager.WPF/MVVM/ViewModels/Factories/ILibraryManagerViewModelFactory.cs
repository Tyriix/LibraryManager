using LibraryManager.WPF.State.Navigation;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public interface ILibraryManagerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
