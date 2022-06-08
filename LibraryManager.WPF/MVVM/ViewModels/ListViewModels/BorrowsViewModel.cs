using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.ListViewModels
{
    /// <summary>
    /// This is a viewModel class for Borrows View.
    /// </summary>
    public class BorrowsViewModel : ViewModelBase
    {
        readonly IDataService<Borrow> borrowDataService = new GenericDataService<Borrow>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Client> clientDataService = new GenericDataService<Client>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<ObservableBorrow> _borrows;

        public ICollection<ObservableBorrow> Borrows => _borrows;
        public ICommand GetBorrows { get; set; }

        public class ObservableBorrow
        {
            public int Id { get; set; }
            public string ClientFullName { get; set; }
            public string BookTitle { get; set; }
            public int BookId { get; set; }
            public int ClientId { get; set; }
            public DateTime BorrowedDate { get; set; }
            public DateTime ReturnedDate { get; set; }
        }

        public BorrowsViewModel()
        {
            IBorrowService getBooksService = new BorrowService(borrowDataService, clientDataService, bookDataService);
            var borrows = getBooksService.GetBorrows();
            _borrows = new ObservableCollection<ObservableBorrow>();
            foreach (var borrow in borrows)
            {
                var client = clientDataService.Get(borrow.ClientId).Result;
                var book = bookDataService.Get(borrow.BookId).Result;
                var newObservableBorrow = new ObservableBorrow()
                {
                    Id = borrow.Id,
                    ClientFullName = client.FirstName + " " + client.LastName,
                    BookTitle = book.Title,
                    BookId = book.Id,
                    ClientId = client.Id,
                    BorrowedDate = borrow.BorrowedDate,
                    ReturnedDate = borrow.ReturnedDate,
                };
                _borrows.Add(newObservableBorrow);
            }
        }
    }
}
