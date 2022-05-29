using LibraryManager.WPF.State.Navigation;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    /// <summary>
    /// This is an interface for creating a new viewModel.
    /// </summary>
    public interface ILibraryManagerViewModelFactory
    {
        ViewModelBase CreateViewModel(ViewType viewType);
    }
}
