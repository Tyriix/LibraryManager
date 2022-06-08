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
    /// Logika interakcji dla klasy BorrowsView.xaml
    /// </summary>
    public partial class BorrowsView : UserControl
    {
        private readonly IDataService<Borrow> borrowDataService = new GenericDataService<Borrow>(new LibraryManagerDbContextFactory());
        public BorrowsView()
        {
            InitializeComponent();
        }
        private void Return_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = button.CommandParameter.ToString();
            var borrows = borrowDataService.GetAll();
            Borrow returnedBorrow = new Borrow();
            foreach (var borrow in borrows)
            {
                if (int.Parse(itemId) == borrow.Id)
                {
                    returnedBorrow = borrow;
                    returnedBorrow.ReturnedDate = DateTime.Now;
                }
            }
            borrowDataService.Update(int.Parse(itemId), returnedBorrow);
            DataContext = new BorrowsViewModel();
        }
        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var itemId = button.CommandParameter.ToString();
            borrowDataService.Delete(int.Parse(itemId));
            DataContext = new BorrowsViewModel();
        }
    }
}
