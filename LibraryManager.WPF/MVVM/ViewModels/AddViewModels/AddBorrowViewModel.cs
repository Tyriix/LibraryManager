using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.WPF.Commands.AddCommands;
using System;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.AddViewModels
{
    /// <summary>
    /// This is a viewModel class for AddBorrow View.
    /// </summary>
    public class AddBorrowViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private DateTime _borrowDate;

        public DateTime BorrowDate
        {
            get { return _borrowDate; }
            set
            {
                _borrowDate = value;
                OnPropertyChanged(nameof(BorrowDate));
            }
        }

        private int _bookId;
        public int BookId
        {
            get { return _bookId; }
            set { _bookId = value; }
        }
        private int _clientId;
        public int ClientId
        {
            get { return _clientId; }
            set { _clientId = value; }
        }

        public ICommand AddBorrowCommand { get; set; }
        public AddBorrowViewModel(IBorrowService addBorrowService)
        {
            AddBorrowCommand = new AddBorrowCommand(this, addBorrowService);
        }
    }
}
