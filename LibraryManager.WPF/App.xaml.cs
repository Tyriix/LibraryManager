using System.Windows;

namespace LibraryManager.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Window window = new LoginWindow();
            window.Show();

            base.OnStartup(e);
        }
    }
}
