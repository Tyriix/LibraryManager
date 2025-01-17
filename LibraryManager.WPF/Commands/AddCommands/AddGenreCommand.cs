﻿using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    /// <summary>
    /// This is an ICommand for creating a new genre.
    /// </summary>
    public class AddGenreCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddGenreViewModel _addViewModel;
        private readonly IDataService<Genre> _dataService;

        public AddGenreCommand(AddGenreViewModel addViewModel, IDataService<Genre> dataService)
        {
            _addViewModel = addViewModel;
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(_addViewModel.Genrename))
            {
                MessageBox.Show("One of the fields was empty, try again.");
                return;
            }
            if (_addViewModel.Genrename.Any(char.IsDigit) == true
                || _addViewModel.Genrename.Any(ch => char.IsSymbol(ch)) == true
                || _addViewModel.Genrename.Any(ch => char.IsPunctuation(ch)) == true)
            {
                MessageBox.Show("Genre name can't contain numbers or symbols, try again.");
                return;
            }

            Genre newGenre = new Genre()
            {
                Name = char.ToUpper(_addViewModel.Genrename[0]) + _addViewModel.Genrename[1..].ToLower()
            };         
            var allGenres = _dataService.GetAll();
            foreach (var item in allGenres)
            {
                if (item.Name == newGenre.Name)
                {
                    MessageBox.Show("This genre already exists");
                    return;
                }
            }
            await _dataService.Create(newGenre);
            MessageBox.Show("New genre added.");

        }

    }
}
