using LibraryManager.WPF.MVVM.ViewModels;
using System.Windows;
namespace LibraryManager.WPF
{
    /// <summary>
    /// Logika interakcji dla klasy LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public bool confirm { get; set; }
        public LoginWindow()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }
        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            Close();
        }
        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            this.WindowState = WindowState.Minimized;
        }
    }
}
