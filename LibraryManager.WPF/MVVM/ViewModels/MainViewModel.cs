using LibraryManager.WPF.Commands;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.State.Navigation;
using System.Windows.Input;

namespace LibraryManager.WPF.ViewModels
{
    /// <summary>
    /// This is a viewModel class for Main View.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        private readonly ILibraryManagerViewModelFactory _rootLibraryManagerViewModelFactory;
        public INavigator Navigator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public MainViewModel(INavigator navigator, ILibraryManagerViewModelFactory rootLibraryManagerViewModelFactory)
        {
            Navigator = navigator;
            _rootLibraryManagerViewModelFactory = rootLibraryManagerViewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_rootLibraryManagerViewModelFactory, navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
