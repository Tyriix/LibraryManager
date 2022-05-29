using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.EntityFramework.Services;
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
