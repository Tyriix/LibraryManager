using LibraryManager.WPF.MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.State.Navigation
{
    public enum ViewType 
    {
        Home,
        AddClient
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
