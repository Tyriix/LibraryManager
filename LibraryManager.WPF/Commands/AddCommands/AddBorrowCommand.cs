using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    /// <summary>
    /// This is an ICommand for creating a new borrow.
    /// </summary>
    public class AddBorrowCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddBorrowViewModel _addViewModel;
        private readonly IBorrowService _addBorrowService;
        private readonly IDataService<Client> clientDataService = new GenericDataService<Client>(new LibraryManagerDbContextFactory());
        private readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new LibraryManagerDbContextFactory());

        public AddBorrowCommand(AddBorrowViewModel viewModel, IBorrowService addBorrowService)
        {
            _addViewModel = viewModel;
            _addBorrowService = addBorrowService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            try
            {
                Client client = await clientDataService.Get(_addViewModel.ClientId);
                Book book = await bookDataService.Get(_addViewModel.BookId);
                Borrow borrow = await _addBorrowService.BorrowBook(new Borrow()
                {
                    BorrowedDate = DateTime.Now,
                    BookId = _addViewModel.BookId,
                    ClientId = _addViewModel.ClientId
                },book, client);

                MessageBox.Show($"Borrowed {book.Title} to {client.FirstName} {client.LastName}.");
            }
            catch (Exception)
            {
                MessageBox.Show("This Client or Book don't exist, try again.");
            }
        }
    }
}
