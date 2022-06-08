using LibraryManager.Domain.Models;
using LibraryManager.Domain.Services;
using LibraryManager.EntityFramework;
using LibraryManager.EntityFramework.Services;
using LibraryManager.WPF.MVVM.ViewModels.ListViewModels;
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
    /// Logika interakcji dla klasy AuthorsView.xaml
    /// </summary>
    public partial class AuthorsView : UserControl
    {
        private readonly IDataService<Author> genreDataService = new GenericDataService<Author>(new LibraryManagerDbContextFactory());

        public AuthorsView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = button.CommandParameter.ToString();
            genreDataService.Delete(int.Parse(itemId));
            DataContext = new AuthorsViewModel();
        }
    }
}
