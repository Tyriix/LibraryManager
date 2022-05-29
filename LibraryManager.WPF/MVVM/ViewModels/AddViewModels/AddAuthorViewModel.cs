using LibraryManager.Domain.Services.AuthorServices;
using LibraryManager.WPF.Commands.AddCommands;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels.AddViewModels
{
    public class AddAuthorViewModel : ViewModelBase
    {
        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _firstname;

        public string Firstname
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(Firstname));
            }
        }
        private string _lastname;

        public string Lastname
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(Lastname));
            }
        }

        public ICommand AddAuthorCommand { get; set; }
        public AddAuthorViewModel(IAuthorService addAuthorService)
        {
            AddAuthorCommand = new AddAuthorCommand(this, addAuthorService);
        }
    }
}
