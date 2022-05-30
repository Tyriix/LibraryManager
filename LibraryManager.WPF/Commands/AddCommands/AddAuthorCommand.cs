using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    /// <summary>
    /// This is an ICommand for creating a new author.
    /// </summary>
    public class AddAuthorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddAuthorViewModel _addViewModel;
        private readonly IAuthorService _addAuthorService;

        public AddAuthorCommand(AddAuthorViewModel viewModel, IAuthorService addAuthorService)
        {
            _addViewModel = viewModel;
            _addAuthorService = addAuthorService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            try
            {
                Author author = await _addAuthorService.AddAuthor(new Author()
                {
                    FirstName = _addViewModel.Firstname,
                    LastName = _addViewModel.Lastname
                });
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
