using LibraryManager.Domain;
using LibraryManager.Domain.Models;
using LibraryManager.WPF.MVVM.ViewModels.AddViewModels;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    /// <summary>
    /// This is an ICommand for creating a new client.
    /// </summary>
    public class AddClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddClientViewModel _addViewModel;
        private readonly IDataService<Client> _dataService;

        public AddClientCommand(AddClientViewModel viewModel, IDataService<Client> dataService)
        {
            _addViewModel = viewModel;
            _dataService = dataService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            try
            {
                Client newClient = new Client()
                {
                    FirstName = char.ToUpper(_addViewModel.Firstname[0]) + _addViewModel.Firstname[1..].ToLower(),
                    LastName = char.ToUpper(_addViewModel.Lastname[0]) + _addViewModel.Lastname[1..].ToLower(),
                    City = char.ToUpper(_addViewModel.City[0]) + _addViewModel.City[1..].ToLower(),
                    Address = _addViewModel.Address,
                    Phone = _addViewModel.Phone,
                    Email = _addViewModel.Email
                };

                if (newClient.FirstName.Any(ch => !char.IsLetter(ch)) == true
                    || newClient.LastName.Any(ch => !char.IsLetter(ch)) == true
                    || newClient.City.Any(ch => !char.IsLetter(ch)) == true)
                {
                    MessageBox.Show("First name, last name or city can't contain numbers or special signs, try again.");
                    return;
                }

                if (newClient.Phone.Any(ch => char.IsLetter(ch)) == true
                    || newClient.Phone.Any(ch => char.IsSymbol(ch)) == true
                    || newClient.Phone.Any(ch => char.IsPunctuation(ch)) == true)
                {
                    MessageBox.Show("Phone number can't contain letters or special signs, try again.");
                    return;
                }

                if (newClient.Phone.Length != 9)
                {
                    MessageBox.Show("Phone number must be 9 digits long.");
                    return;
                }

                var allClients = _dataService.GetAll();
                foreach (var item in allClients)
                {
                    if (item.FirstName == newClient.FirstName
                        && item.LastName == newClient.LastName
                        && item.City == newClient.City
                        && item.Address == newClient.Address
                        && item.Phone == newClient.Phone
                        && item.Email == newClient.Email)
                    {
                        MessageBox.Show("This client already exists");
                        return;
                    }
                }
                await _dataService.Create(newClient);
                MessageBox.Show("New client added.");
            }
            catch (Exception)
            {
                MessageBox.Show("One of the fields was empty, try again.");
            }
        }
    }
}
