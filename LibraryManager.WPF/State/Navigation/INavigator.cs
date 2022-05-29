using LibraryManager.WPF.MVVM.ViewModels;

namespace LibraryManager.WPF.State.Navigation
{
    public enum ViewType 
    {
        Home,
        Clients,
        Borrows,
        Genres,
        Books,
        Authors,
        AddClient,
        AddGenre,
        AddAuthor,
        AddBook,
        AddBorrow
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
