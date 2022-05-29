using LibraryManager.WPF.Models;
using LibraryManager.WPF.MVVM.ViewModels;

namespace LibraryManager.WPF.State.Navigation
{
    /// <summary>
    /// This is a class that's used to navigate through views.
    /// When navigation property changes it sets a new view model.
    /// </summary>
    public class Navigator : ObservableObject, INavigator
    {
        private ViewModelBase _currentViewModel;
        public ViewModelBase CurrentViewModel
        {
            get 
            {
                return _currentViewModel;
            }
            set
            {
                _currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }
    }
}
