using Caliburn.Micro;
using LibraryManager.WPF.Core;
using System;
using System.Collections.Generic;
using System.Text;

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
        public void LogIn(string username, string password)
        {
            Console.WriteLine();
        }
    }
}
