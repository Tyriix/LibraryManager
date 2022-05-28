using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddClientViewModelFactory : ILibraryManagerViewModelFactory<AddClientViewModel>
    {
        public AddClientViewModel CreateViewModel()
        {
            return new AddClientViewModel();
        }
    }
}
