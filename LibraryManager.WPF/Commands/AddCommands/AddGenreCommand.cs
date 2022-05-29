using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.WPF.MVVM.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    public class AddGenreCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddGenreViewModel _addViewModel;
        private readonly IAddGenreService _addGenreService;

        public AddGenreCommand(AddGenreViewModel addViewModel, IAddGenreService addGenreService)
        {
            _addViewModel = addViewModel;
            _addGenreService = addGenreService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            try
            {
                Genre genre = await _addGenreService.AddGenre(new Genre()
                {
                    Name = _addViewModel.Genrename
                });

                MessageBox.Show("New genre added.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
