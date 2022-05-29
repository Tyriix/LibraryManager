using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
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
        private readonly ILibraryManagerViewModelFactory<BooksViewModel> _booksViewModelFactory;

        private readonly ILibraryManagerViewModelFactory<AddClientViewModel> _addClientViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddGenreViewModel> _addGenreViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddAuthorViewModel> _addAuthorViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddBookViewModel> _addBookViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddBorrowViewModel> _addBorrowViewModelFactory;

        public RootLibraryManagerViewModelFactory(ILibraryManagerViewModelFactory<HomeViewModel> homeViewModelFactory, ILibraryManagerViewModelFactory<ClientsViewModel> clientsViewModelFactory, ILibraryManagerViewModelFactory<GenresViewModel> genresViewModelFactory, ILibraryManagerViewModelFactory<AuthorsViewModel> authorsViewModelFactory, ILibraryManagerViewModelFactory<BooksViewModel> booksViewModelFactory, ILibraryManagerViewModelFactory<AddClientViewModel> addClientViewModelFactory, ILibraryManagerViewModelFactory<AddGenreViewModel> addGenreViewModelFactory, ILibraryManagerViewModelFactory<AddAuthorViewModel> addAuthorViewModelFactory, ILibraryManagerViewModelFactory<AddBookViewModel> addBookViewModelFactory, ILibraryManagerViewModelFactory<AddBorrowViewModel> addBorrowViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _clientsViewModelFactory = clientsViewModelFactory;
            _genresViewModelFactory = genresViewModelFactory;
            _authorsViewModelFactory = authorsViewModelFactory;
            _booksViewModelFactory = booksViewModelFactory;
            _addClientViewModelFactory = addClientViewModelFactory;
            _addGenreViewModelFactory = addGenreViewModelFactory;
            _addAuthorViewModelFactory = addAuthorViewModelFactory;
            _addBookViewModelFactory = addBookViewModelFactory;
            _addBorrowViewModelFactory = addBorrowViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _homeViewModelFactory.CreateViewModel(),
                ViewType.Clients => _clientsViewModelFactory.CreateViewModel(),
                ViewType.Genres => _genresViewModelFactory.CreateViewModel(),
                ViewType.Authors => _authorsViewModelFactory.CreateViewModel(),
                ViewType.Books => _booksViewModelFactory.CreateViewModel(),
                ViewType.AddClient => _addClientViewModelFactory.CreateViewModel(),
                ViewType.AddGenre => _addGenreViewModelFactory.CreateViewModel(),
                ViewType.AddAuthor => _addAuthorViewModelFactory.CreateViewModel(),
                ViewType.AddBook => _addBookViewModelFactory.CreateViewModel(),
                ViewType.AddBorrow => _addBorrowViewModelFactory.CreateViewModel(),
                _ => throw new ArgumentException("This ViewType doesn't exist.", "viewType"),
            };
        }
    }
}
