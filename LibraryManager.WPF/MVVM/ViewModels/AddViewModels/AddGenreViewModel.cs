using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.WPF.Commands.AddCommands;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.AddViewModels
{
    /// <summary>
    /// This is a viewModel class for AddGenre View.
    /// </summary>
    public class AddGenreViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _genrename;

        public string Genrename
        {
            get { return _genrename; }
            set
            {
                _genrename = value;
                OnPropertyChanged(nameof(Genrename));
            }
        }

        public ICommand AddGenreCommand { get; set; }
        public AddGenreViewModel(IDataService<Genre> dataService)
        {
            AddGenreCommand = new AddGenreCommand(this, dataService);
        }
    }
}
