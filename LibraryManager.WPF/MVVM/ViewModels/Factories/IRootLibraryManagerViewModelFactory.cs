using LibraryManager.WPF.State.Navigation;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public interface IRootLibraryManagerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
