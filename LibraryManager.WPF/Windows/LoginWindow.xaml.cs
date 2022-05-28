using LibraryManager.WPF.MVVM.ViewModels;
using System.Windows;

namespace LibraryManager.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool Confirm { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm = true;
            Close();
        }
        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            Confirm = true;
            WindowState = WindowState.Minimized;
        }
    }
}
