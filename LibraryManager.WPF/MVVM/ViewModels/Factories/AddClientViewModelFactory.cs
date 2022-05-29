using LibraryManager.Domain.Services.ClientServices;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;

namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class AddClientViewModelFactory : ILibraryManagerViewModelFactory<AddClientViewModel>
    {
        private IClientService AddClientService { get; set; }

        public AddClientViewModelFactory(IClientService addClientService)
        {
            AddClientService = addClientService;
        }

        public AddClientViewModel CreateViewModel()
        {
            return new AddClientViewModel(AddClientService);
        }
    }
}
