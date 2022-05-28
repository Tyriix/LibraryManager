
namespace LibraryManager.WPF.MVVM.ViewModels.Factories
{
    public class HomeViewModelFactory : ILibraryManagerViewModelFactory<HomeViewModel>
    {
        public HomeViewModel CreateViewModel()
        {
            return new HomeViewModel();
        }
    }
}
