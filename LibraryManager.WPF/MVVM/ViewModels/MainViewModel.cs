using LibraryManager.WPF.Core;
using LibraryManager.WPF.MVVM.ViewModels;

namespace LibraryManager.WPF.ViewModels
{
    class MainViewModel : ObservableObject
    {
        public RelayCommand homeViewCommand { get; set; }
        public RelayCommand clientsViewCommand { get; set; }
        public HomeViewModel HomeVM { get; set; }
        public ClientsViewModel ClientsVM { get; set; }
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
            HomeVM = new HomeViewModel();
            ClientsVM = new ClientsViewModel();
            CurrentView = HomeVM;

            homeViewCommand = new RelayCommand(o =>
            {
                CurrentView = HomeVM;
            });
            clientsViewCommand = new RelayCommand(o =>
            {
                CurrentView = ClientsVM;
            });
        }
    }
}
