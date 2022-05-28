using LibraryManager.Domain.Services;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddClientViewModelFactory : ILibraryManagerViewModelFactory<AddClientViewModel>
    {
        private IAddClientService AddClientService { get; set; }

        public AddClientViewModelFactory(IAddClientService addClientService)
        {
            AddClientService = addClientService;
        }

        public AddClientViewModel CreateViewModel()
        {
            return new AddClientViewModel(AddClientService);
        }
    }
}
