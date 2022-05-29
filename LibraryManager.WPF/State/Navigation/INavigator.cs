using LibraryManager.WPF.MVVM.ViewModels;
using System.Windows.Input;

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
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
