using LibraryManager.Domain.Services.BorrowServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddBorrowViewModelFactory : ILibraryManagerViewModelFactory<AddBorrowViewModel>
    {
        private IBorrowService AddBorrowService { get; set; }

        public AddBorrowViewModelFactory(IBorrowService addBorrowService)
        {
            AddBorrowService = addBorrowService;
        }

        public AddBorrowViewModel CreateViewModel()
        {
            return new AddBorrowViewModel(AddBorrowService);
        }
    }
}
