using LibraryManager.WPF.Models;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    /// <summary>
    /// This is a delegate that represents a function that returns a Generic viewModelType with ViewModelBase constraint.
    /// </summary>
    public delegate TViewModel CreateViewModel<TViewModel>() where TViewModel : ViewModelBase; 

    public class ViewModelBase : ObservableObject
    {
    }
}
