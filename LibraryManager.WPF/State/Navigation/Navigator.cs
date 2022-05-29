using LibraryManager.WPF.Models;
using LibraryManager.WPF.MVVM.ViewModels;

namespace LibraryManager.WPF.State.Navigation
{
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
