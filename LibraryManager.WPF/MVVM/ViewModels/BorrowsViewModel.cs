using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BookServices;
using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.EntityFramework.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    public class BorrowsViewModel : ViewModelBase
    {
        readonly IDataService<Borrow> borrowDataService = new GenericDataService<Borrow>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new EntityFramework.LibraryManagerDbContextFactory());
        readonly IDataService<Client> clientDataService = new GenericDataService<Client>(new EntityFramework.LibraryManagerDbContextFactory());
        private readonly ObservableCollection<Borrow> _borrows;

        public ICollection<Borrow> Borrows => _borrows;
        public ICommand GetBorrows { get; set; }

        public BorrowsViewModel()
        {
            IBorrowService getBooksService = new BorrowService(borrowDataService, clientDataService, bookDataService);
            var borrows = getBooksService.GetBorrows();

            _borrows = new ObservableCollection<Borrow>(borrows);
        }
    }
}
