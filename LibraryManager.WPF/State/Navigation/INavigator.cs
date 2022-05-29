using LibraryManager.WPF.MVVM.ViewModels;

namespace LibraryManager.WPF.State.Navigation
{
    /// <summary>
    /// This is a enum helper for selecting viewModel.
    /// </summary>
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
    /// <summary>
    /// This is an interface for setting current view model.
    /// </summary>
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
    }
}
