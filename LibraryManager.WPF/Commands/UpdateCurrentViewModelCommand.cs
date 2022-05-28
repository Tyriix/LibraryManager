using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands
{
    public class UpdateCurrentViewModelCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly INavigator _navigator;

        public UpdateCurrentViewModelCommand(INavigator navigator)
        {
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
                switch (viewType)
                {
                    case ViewType.Home:
                        _navigator.CurrentViewModel = new HomeViewModel();
                        break;
                    case ViewType.AddClient:
                        _navigator.CurrentViewModel = new AddClientViewModel();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
