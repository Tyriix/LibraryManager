using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
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
        private readonly IGenreService _addGenreService;

        public AddGenreCommand(AddGenreViewModel addViewModel, IGenreService addGenreService)
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
