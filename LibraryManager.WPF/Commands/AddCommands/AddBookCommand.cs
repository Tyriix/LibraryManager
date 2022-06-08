using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    /// <summary>
    /// This is an ICommand for creating a new book.
    /// </summary>
    public class AddBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddBookViewModel _addViewModel;
        private readonly IDataService<Book> _dataService;
        private readonly IDataService<Genre> genreDataService = new GenericDataService<Genre>(new LibraryManagerDbContextFactory());

        public AddBookCommand(AddBookViewModel viewModel, IDataService<Book> dataService)
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
            if (string.IsNullOrWhiteSpace(_addViewModel.Title)
                || string.IsNullOrWhiteSpace(_addViewModel.GenreName))
            {
                MessageBox.Show("One of the fields was empty, try again.");
                return;
            }
            if (_addViewModel.Title.Any(ch => char.IsSymbol(ch)) == true
                || _addViewModel.Title.Any(ch => char.IsPunctuation(ch)) == true)
            {
                MessageBox.Show("Title name can't contain symbols or special signs, try again.");
                return;
            }

            var genres = genreDataService.GetAll();
            Genre genre = new Genre();

            foreach (var item in genres)
            {
                if (item.Name == _addViewModel.GenreName)
                {
                    genre = await genreDataService.Get(item.Id);
                }
            }

            Book newBook = new Book()
            {
                Title = char.ToUpper(_addViewModel.Title[0]) + _addViewModel.Title[1..].ToLower(),
                PageCount = _addViewModel.PageCount,
                PublishDate = _addViewModel.PublishDate,
                AuthorId = _addViewModel.AuthorId,
                GenreId = genre.Id
            };

            if (newBook.PageCount <= 0)
            {
                MessageBox.Show("Book can't have 0 or less pages, try again.");
                return;
            }

            await _dataService.Create(newBook);
            MessageBox.Show("New book added.");

        }
    }
}
