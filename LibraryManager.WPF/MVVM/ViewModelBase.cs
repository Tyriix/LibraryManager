using LibraryManager.WPF.Models;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase; 

    public class ViewModelBase : ObservableObject
    {
    }
}
