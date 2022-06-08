using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Linq;
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
        private readonly IDataService<Author> _dataService;

        public AddAuthorCommand(AddAuthorViewModel viewModel, IDataService<Author> dataService)
        {
            _addViewModel = viewModel;
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            if (string.IsNullOrWhiteSpace(_addViewModel.Firstname)
                || string.IsNullOrWhiteSpace(_addViewModel.Lastname))
            {
                MessageBox.Show("One of the fields was empty, try again.");
                return;
            }

            if (_addViewModel.Firstname.Any(ch => !char.IsLetter(ch)) == true
                || _addViewModel.Lastname.Any(ch => !char.IsLetter(ch)) == true)
            {
                MessageBox.Show("First name or last name can't contain numbers or special signs, try again.");
                return;
            }

            Author newAuthor = new Author()
            {
                FirstName = char.ToUpper(_addViewModel.Firstname[0]) + _addViewModel.Firstname.Substring(1).ToLower(),
                LastName = char.ToUpper(_addViewModel.Lastname[0]) + _addViewModel.Lastname.Substring(1).ToLower()
            };
            var allAuthors = _dataService.GetAll();
            foreach (var item in allAuthors)
            {
                if (item.FirstName == newAuthor.FirstName
                    && item.LastName == newAuthor.LastName)
                {
                    MessageBox.Show("This author already exists");
                    return;
                }
            }

            await _dataService.Create(newAuthor);
            MessageBox.Show("New author added.");
        }
    }
}
