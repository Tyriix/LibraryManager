using LibraryManager.Domain;
using LibraryManager.Domain.Models;
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
        private readonly IDataService<Borrow> _dataService;
        private readonly IDataService<Client> clientDataService = new GenericDataService<Client>(new LibraryManagerDbContextFactory());
        private readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new LibraryManagerDbContextFactory());

        public AddBorrowCommand(AddBorrowViewModel viewModel, IDataService<Borrow> dataService)
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
            try
            {
                Client client = await clientDataService.Get(_addViewModel.ClientId);
                Book book = await bookDataService.Get(_addViewModel.BookId);
                Borrow newBorrow = new Borrow()
                {
                    BorrowedDate = DateTime.Now,
                    ClientId = client.Id,
                    BookId = book.Id
                };

                await _dataService.Create(newBorrow);
                MessageBox.Show($"Borrowed {book.Title} to {client.FirstName} {client.LastName}.");
            }
            catch (Exception)
            {
                MessageBox.Show("This Client or Book don't exist, try again.");
            }
        }
    }
}
