using Caliburn.Micro;

namespace LibraryManager.WPF.MVVM.ViewModels
{
    class LoginViewModel : Screen
    {
        private string _userName;
        private string _password;
        public string Username
        {
            get { return _userName; }
            set
            {
                _userName = value;
                NotifyOfPropertyChange(() => Username);
            }
        }
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                NotifyOfPropertyChange(() => Password);
            }
        }
    }
}
