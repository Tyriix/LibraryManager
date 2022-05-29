using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class BooksViewModelFactory : ILibraryManagerViewModelFactory<BooksViewModel>
    {
        public BooksViewModel CreateViewModel()
        {
            return new BooksViewModel();
        }
    }
}
