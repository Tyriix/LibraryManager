using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class BorrowsViewModelFactory : ILibraryManagerViewModelFactory<BorrowsViewModel>
    {
        public BorrowsViewModel CreateViewModel()
        {
            return new BorrowsViewModel();
        }
    }
}
