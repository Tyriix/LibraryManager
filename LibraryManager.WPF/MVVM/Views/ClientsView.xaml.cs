using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LibraryManager.WPF.MVVM.Views
{
    /// <summary>
    /// Logika interakcji dla klasy ClientsView.xaml
    /// </summary>
    public partial class ClientsView : UserControl
    {
        public ClientsView()
        {
            InitializeComponent();
            List<Client> items = new List<Client>();
            items.Add(new Client() { FirstName = "John Doe", Phone = "997997997" });
            lvDataBinding.ItemsSource = items;
        }
    }
}
