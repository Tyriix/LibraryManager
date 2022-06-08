using LibraryManager.Domain;
using LibraryManager.Domain.Models;
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
        private readonly IDataService<Author> authorDataService = new GenericDataService<Author>(new LibraryManagerDbContextFactory());
        private readonly IDataService<Book> bookDataService = new GenericDataService<Book>(new LibraryManagerDbContextFactory());

        public AuthorsView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = button.CommandParameter.ToString();
            var books = bookDataService.GetAll();
            foreach (var book in books)
            {
                if (book.GenreId == int.Parse(itemId))
                {
                    if (MessageBox.Show("There are books that use this author. \nDo you want to delete the autor and books that use it?", "", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        return;
                    }
                }
            }
            authorDataService.Delete(int.Parse(itemId));
            DataContext = new AuthorsViewModel();
        }
    }
}
