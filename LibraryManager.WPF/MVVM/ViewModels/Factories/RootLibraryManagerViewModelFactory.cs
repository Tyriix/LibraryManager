using LibraryManager.WPF.State.Navigation;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class RootLibraryManagerViewModelFactory : IRootLibraryManagerViewModelFactory
    {
        private readonly ILibraryManagerViewModelFactory<HomeViewModel> _homeViewModelFactory;
        private readonly ILibraryManagerViewModelFactory<AddClientViewModel> _addClientViewModelFactory;

        public RootLibraryManagerViewModelFactory(ILibraryManagerViewModelFactory<HomeViewModel> homeViewModelFactory, 
            ILibraryManagerViewModelFactory<AddClientViewModel> addClientViewModelFactory)
        {
            _homeViewModelFactory = homeViewModelFactory;
            _addClientViewModelFactory = addClientViewModelFactory;
        }

        public ViewModelBase CreateViewModel(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Home:
                    return _homeViewModelFactory.CreateViewModel();
                case ViewType.AddClient:
                    return _addClientViewModelFactory.CreateViewModel();
                default:
                    throw new ArgumentException("This ViewType doesn't exist.", "viewType");
            }
        }
    }
}
