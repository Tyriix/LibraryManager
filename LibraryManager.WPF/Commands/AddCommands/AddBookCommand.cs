using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    public class AddBookCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddBookViewModel _addViewModel;
        private readonly IBookService _addBookService;
        private readonly IDataService<Author> authorDataService = new GenericDataService<Author>(new LibraryManagerDbContextFactory());
        private readonly IDataService<Genre> genreDataService = new GenericDataService<Genre>(new LibraryManagerDbContextFactory());

        public AddBookCommand(AddBookViewModel viewModel, IBookService addBookService)
        {
            _addViewModel = viewModel;
            _addBookService = addBookService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            try
            {
                Author author = await authorDataService.Get(1);
                Genre genre = await genreDataService.Get(1);
                Book book = await _addBookService.AddBook(new Book()
                {
                    Title = _addViewModel.Title,
                    PageCount = _addViewModel.PageCount,
                    PublishDate = _addViewModel.PublishDate,
                    AuthorId = _addViewModel.AuthorId,
                    GenreId = _addViewModel.GenreId
                }, author, genre);

                MessageBox.Show("New book added.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
