using LibraryManager.WPF.MVVM.ViewModels;
using System.Windows.Input;

namespace LibraryManager.WPF.State.Navigation
{
    public enum ViewType 
    {
        Home,
        Clients,
        Genres,
        Authors,
        AddClient,
        AddGenre,
        AddAuthor
    }
    public interface INavigator
    {
        ViewModelBase CurrentViewModel { get; set; }
        ICommand UpdateCurrentViewModelCommand { get; }
    }
}
