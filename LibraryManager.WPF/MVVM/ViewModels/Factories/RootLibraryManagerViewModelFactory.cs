using LibraryManager.WPF.State.Navigation;
using System;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class RootLibraryManagerViewModelFactory : IRootLibraryManagerViewModelFactory
    {
        private readonly ILibraryManagerViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<ClientsViewModel> _clientsViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<GenresViewModel> _genresViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AuthorsViewModel> _authorsViewModelFactory;

        private readonly ILibraryManagerViewModelFactory<AddClientViewModel> _addClientViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddGenreViewModel> _addGenreViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddAuthorViewModel> _addAuthorViewModelFactory;

        public RootLibraryManagerViewModelFactory(ILibraryManagerViewModelFactory<HomeViewModel> homeViewModelFactory, ILibraryManagerViewModelFactory<ClientsViewModel> clientsViewModelFactory, ILibraryManagerViewModelFactory<GenresViewModel> genresViewModelFactory, ILibraryManagerViewModelFactory<AuthorsViewModel> authorsViewModelFactory, ILibraryManagerViewModelFactory<AddClientViewModel> addClientViewModelFactory, ILibraryManagerViewModelFactory<AddGenreViewModel> addGenreViewModelFactory, ILibraryManagerViewModelFactory<AddAuthorViewModel> addAuthorViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _clientsViewModelFactory = clientsViewModelFactory;
            _genresViewModelFactory = genresViewModelFactory;
            _authorsViewModelFactory = authorsViewModelFactory;
            _addClientViewModelFactory = addClientViewModelFactory;
            _addGenreViewModelFactory = addGenreViewModelFactory;
            _addAuthorViewModelFactory = addAuthorViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _homeViewModelFactory.CreateViewModel(),
                ViewType.Clients => _clientsViewModelFactory.CreateViewModel(),
                ViewType.Genres => _genresViewModelFactory.CreateViewModel(),
                ViewType.Authors => _authorsViewModelFactory.CreateViewModel(),
                ViewType.AddClient => _addClientViewModelFactory.CreateViewModel(),
                ViewType.AddGenre => _addGenreViewModelFactory.CreateViewModel(),
                ViewType.AddAuthor => _addAuthorViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException("This ViewType doesn't exist.", "viewType"),
            };
        }
    }
}
