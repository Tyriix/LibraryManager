using LibraryManager.WPF.Models;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    /// <summary>
    /// This is a delegate that represents a function that returns a Generic viewModelType with ViewModelBase constraint.
    /// </summary>
    public delegate T CreateViewModel<T>() where T : ViewModelBase; 

    public class ViewModelBase : ObservableObject
    {
    }
}
