using LibraryManager.Domain.Services.GenreServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class GenresViewModelFactory : ILibraryManagerViewModelFactory<GenresViewModel>
    {
        public GenresViewModel CreateViewModel()
        {
            return new GenresViewModel();
        }
    }
}
