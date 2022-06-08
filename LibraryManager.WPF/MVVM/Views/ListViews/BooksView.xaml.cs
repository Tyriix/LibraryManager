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
    /// Logika interakcji dla klasy BooksView.xaml
    /// </summary>
    public partial class BooksView : UserControl
    {
        private readonly IDataService<Book> genreDataService = new GenericDataService<Book>(new LibraryManagerDbContextFactory());
        private readonly IDataService<Borrow> borrowDataService = new GenericDataService<Borrow>(new LibraryManagerDbContextFactory());

        public BooksView()
        {
            InitializeComponent();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = button.CommandParameter.ToString();
            var borrows = borrowDataService.GetAll();
            foreach (var borrow in borrows)
            {
                if (borrow.ClientId == int.Parse(itemId))
                {
                    if (MessageBox.Show("There are borrows that use this book. \nDo you want to delete the book and borrows that use it?", "", MessageBoxButton.YesNo) == MessageBoxResult.No)
                    {
                        return;
                    }
                    break;
                }
            }
            genreDataService.Delete(int.Parse(itemId));
            DataContext = new BooksViewModel();
        }
    }
}
