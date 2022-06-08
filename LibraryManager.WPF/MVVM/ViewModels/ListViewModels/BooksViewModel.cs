using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.EntityFramework.Services;
using System;
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

        private readonly ObservableCollection<ObservableBook> _books;

        public ICollection<ObservableBook> Books => _books;
        public ICommand GetBooks { get; set; }

        public class ObservableBook
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public int PageCount { get; set; }
            public DateTime PublishDate { get; set; }

            public string AuthorFullName { get; set; }
            public string GenreName { get; set; }
        }

        public BooksViewModel()
        {
            
            IBookService getBooksService = new BookService(bookDataService);
            
            var books = getBooksService.GetBooks();
            _books = new ObservableCollection<ObservableBook>();
            foreach (var book in books)
            {
                var author = authorDataService.Get(book.AuthorId).Result;
                var genre = genreDataService.Get(book.GenreId).Result;
                var newObservableBook = new ObservableBook()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageCount = book.PageCount,
                    PublishDate = book.PublishDate,
                    AuthorFullName = author.FirstName + " " + author.LastName,
                    GenreName = genre.Name
                };
                _books.Add(newObservableBook);
            }
        }
    }
}
