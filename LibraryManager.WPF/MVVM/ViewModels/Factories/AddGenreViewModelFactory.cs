using LibraryManager.Domain.Services.GenreServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddGenreViewModelFactory : ILibraryManagerViewModelFactory<AddGenreViewModel>
    {
        private IGenreService AddGenreService { get; set; }

        public AddGenreViewModelFactory(IGenreService addGenreService)
        {
            AddGenreService = addGenreService;
        }

        public AddGenreViewModel CreateViewModel()
        {
            return new AddGenreViewModel(AddGenreService);
        }
    }
}
