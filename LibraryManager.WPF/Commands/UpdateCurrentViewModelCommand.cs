using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.State.Navigation;
using System;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add {} remove {} }
        private readonly IRootLibraryManagerViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(IRootLibraryManagerViewModelFactory viewModelFactory, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
