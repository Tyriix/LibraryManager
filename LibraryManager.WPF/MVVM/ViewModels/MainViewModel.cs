using LibraryManager.WPF.Core;

namespace LibraryManager.WPF.ViewModels
{
    class MainViewModel : ObservableObject
    {
        private object _currentView;

        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
        }
    }
}
