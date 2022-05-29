using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using LibraryManager.WPF.MVVM.ViewModels.ListViewModels;
using LibraryManager.WPF.State.Navigation;
using System;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class LibraryManagerViewModelFactory : ILibraryManagerViewModelFactory
    {
        private readonly CreateViewModel<HomeViewModel> _createHomeViewModel;
        private readonly CreateViewModel<ClientsViewModel> _createClientsViewModel;
        private readonly CreateViewModel<GenresViewModel> _createGenresViewModel;
        private readonly CreateViewModel<AuthorsViewModel> _createAuthorsViewModel;
        private readonly CreateViewModel<BooksViewModel> _createBooksViewModel;
        private readonly CreateViewModel<BorrowsViewModel> _createBorrowsViewModel;


        private readonly CreateViewModel<AddClientViewModel> _createAddClientViewModel;
        private readonly CreateViewModel<AddGenreViewModel> _createAddGenreViewModel;
        private readonly CreateViewModel<AddAuthorViewModel> _createAddAuthorViewModel;
        private readonly CreateViewModel<AddBookViewModel> _createAddBookViewModel;
        private readonly CreateViewModel<AddBorrowViewModel> _createAddBorrowViewModel;

        public LibraryManagerViewModelFactory(CreateViewModel<HomeViewModel> createHomeViewModel,
                CreateViewModel<ClientsViewModel> createClientsViewModel,
                CreateViewModel<GenresViewModel> createGenresViewModel,
                CreateViewModel<AuthorsViewModel> createAuthorsViewModel,
                CreateViewModel<BooksViewModel> createBooksViewModel,
                CreateViewModel<BorrowsViewModel> createBorrowsViewModel,
                CreateViewModel<AddClientViewModel> createAddClientViewModel,
                CreateViewModel<AddGenreViewModel> createAddGenreViewModel,
                CreateViewModel<AddAuthorViewModel> createAddAuthorViewModel,
                CreateViewModel<AddBookViewModel> createAddBookViewModel,
                CreateViewModel<AddBorrowViewModel> createAddBorrowViewModel)
        {
            _createHomeViewModel = createHomeViewModel;
            _createClientsViewModel = createClientsViewModel;
            _createGenresViewModel = createGenresViewModel;
            _createAuthorsViewModel = createAuthorsViewModel;
            _createBooksViewModel = createBooksViewModel;
            _createBorrowsViewModel = createBorrowsViewModel;
            _createAddClientViewModel = createAddClientViewModel;
            _createAddGenreViewModel = createAddGenreViewModel;
            _createAddAuthorViewModel = createAddAuthorViewModel;
            _createAddBookViewModel = createAddBookViewModel;
            _createAddBorrowViewModel = createAddBorrowViewModel;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            return viewType switch
            {
                ViewType.Home => _createHomeViewModel(),
                ViewType.Clients => _createClientsViewModel(),
                ViewType.Borrows => _createBorrowsViewModel(),
                ViewType.Genres => _createGenresViewModel(),
                ViewType.Authors => _createAuthorsViewModel(),
                ViewType.Books => _createBooksViewModel(),
                ViewType.AddClient => _createAddClientViewModel(),
                ViewType.AddGenre => _createAddGenreViewModel(),
                ViewType.AddAuthor => _createAddAuthorViewModel(),
                ViewType.AddBook => _createAddBookViewModel(),
                ViewType.AddBorrow => _createAddBorrowViewModel(),
                _ => throw new ArgumentException("This ViewType doesn't exist.", "viewType"),
            };
        }
    }
}
