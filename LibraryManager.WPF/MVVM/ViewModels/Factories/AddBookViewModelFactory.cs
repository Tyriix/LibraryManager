using LibraryManager.Domain.Services.BookServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddBookViewModelFactory : ILibraryManagerViewModelFactory<AddBookViewModel>
    {
        private IBookService AddBookService { get; set; }

        public AddBookViewModelFactory(IBookService addBookService)
        {
            AddBookService = addBookService;
        }

        public AddBookViewModel CreateViewModel()
        {
            return new AddBookViewModel(AddBookService);
        }
    }
}
