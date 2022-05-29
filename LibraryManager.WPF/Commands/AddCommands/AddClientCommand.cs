using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services.ClientServices;
using LibraryManager.WPF.MVVM.ViewModels;
using System;
using System.Windows;
using System.Windows.Input;

namespace LibraryManager.WPF.Commands.AddCommands
{
    public class AddClientCommand : ICommand
    {
        public event EventHandler CanExecuteChanged { add { } remove { } }
        private readonly AddClientViewModel _addViewModel;
        private readonly IAddClientService _addClientService;

        public AddClientCommand(AddClientViewModel viewModel, IAddClientService addClientService)
        {
            _addViewModel = viewModel;
            _addClientService = addClientService;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }
        public async void Execute(object parameter)
        {
            try
            {
                Client client = await _addClientService.AddClient(new Client()
                {
                    FirstName = _addViewModel.Firstname,
                    LastName = _addViewModel.Lastname,
                    City = _addViewModel.City,
                    Address = _addViewModel.Address,
                    Phone = _addViewModel.Phone,
                    Email = _addViewModel.Email
                });

                MessageBox.Show("New client added.");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
    }
}
