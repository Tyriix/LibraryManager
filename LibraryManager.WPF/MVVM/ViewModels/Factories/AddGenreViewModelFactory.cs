using LibraryManager.Domain.Services.GenreServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddGenreViewModelFactory : ILibraryManagerViewModelFactory<AddGenreViewModel>
    {
        private IAddGenreService AddGenreService { get; set; }

        public AddGenreViewModelFactory(IAddGenreService addGenreService)
        {
            AddGenreService = addGenreService;
        }

        public AddGenreViewModel CreateViewModel()
        {
            return new AddGenreViewModel(AddGenreService);
        }
    }
}
