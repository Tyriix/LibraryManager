using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.EntityFramework.Services;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{
    /// <summary>
    /// This is a viewModel class for Books View.
    /// </summary>
    public class BooksViewModel : ViewModelBase
    {
        readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Author> authorDataService = new GenericDataService<Author>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Genre> genreDataService = new GenericDataService<Genre>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Book> _books;

        public ICollection<Book> Books => _books;
        public ICommand GetBooks { get; set; }

        public BooksViewModel()
        {
            IBookService getBooksService = new BookService(bookDataService, authorDataService, genreDataService);
            var books = getBooksService.GetBooks();

            _books = new ObservableCollection<Book>(books);
        }
    }
}
