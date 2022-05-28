using LibraryManager.Domain.Services;
using LibraryManager.WPF.Commands;
using System.Windows.Input;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    public class AddClientViewModel : ViewModelBase
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

        private string _city;

        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                OnPropertyChanged(nameof(City));
            }
        }
        private string _address;

        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        private string _phone;

        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string _email;  

        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                OnPropertyChanged(nameof(Email));
            }
        }
        public ICommand AddClientCommand { get; set; }
        public AddClientViewModel(IAddClientService addClientService)
        {
            AddClientCommand = new AddClientCommand(this, addClientService);
        }
    }
}
