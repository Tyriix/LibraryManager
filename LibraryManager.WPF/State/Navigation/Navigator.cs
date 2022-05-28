﻿using LibraryManager.WPF.Commands;
using LibraryManager.WPF.Models;
using LibraryManager.WPF.MVVM.ViewModels;
using LibraryManager.WPF.MVVM.ViewModels.Factories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.State.Navigation
{
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
        public ICommand UpdateCurrentViewModelCommand { get; set; }

        public Navigator(IRootLibraryManagerViewModelFactory viewModelFactory)
        {
            UpdateCurrentViewModelCommand = new UpdateCurrentViewModelCommand(viewModelFactory, this);
        }
    }
}
