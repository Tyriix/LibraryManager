using LibraryManager.WPF.Commands;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.State.Navigation;
using System.Windows.Input;

namespace LibraryManager.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IRootLibraryManagerViewModelFactory _rootLibraryManagerViewModelFactory;
        public INavigator Navigator { get; set; }
        public ICommand UpdateCurrentViewModelCommand { get; }
        public MainViewModel(INavigator navigator, IRootLibraryManagerViewModelFactory rootLibraryManagerViewModelFactory)
        {
            Navigator = navigator;
            _rootLibraryManagerViewModelFactory = rootLibraryManagerViewModelFactory;

            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(_rootLibraryManagerViewModelFactory, navigator);
            UpdateCurrentViewModelCommand.Execute(ViewType.Home);
        }
    }
}
