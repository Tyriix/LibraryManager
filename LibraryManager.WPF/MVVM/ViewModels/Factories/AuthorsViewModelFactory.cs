using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AuthorsViewModelFactory : ILibraryManagerViewModelFactory<AuthorsViewModel>
    {
        public AuthorsViewModel CreateViewModel()
        {
            return new AuthorsViewModel();
        }
    }
}
