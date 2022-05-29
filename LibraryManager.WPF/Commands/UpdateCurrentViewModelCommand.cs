using LibraryManager.WPF.MVVM.ViewModels.Factories;
using LibraryManager.WPF.State.Navigation;
using System;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands
{
    /// <summary>
    /// This is an ICommand for updating a viewModel.
    /// </summary>
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add {} remove {} }
        private readonly ILibraryManagerViewModelFactory _viewModelFactory;
        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(ILibraryManagerViewModelFactory viewModelFactory, INavigator navigator)
        {
            _viewModelFactory = viewModelFactory;
            _navigator = navigator;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        /// <summary>
        /// This is a function that takes in a ViewType enum parameter and passes it to CreateViewModel function.
        /// </summary>
        public void Execute(object parameter)
        {
            if (parameter is ViewType viewType)
            {
                _navigator.CurrentViewModel = _viewModelFactory.CreateViewModel(viewType);
            }
        }
    }
}
