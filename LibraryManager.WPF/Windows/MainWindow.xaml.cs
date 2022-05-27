using System.Windows;

namespace LibraryManager.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public bool confirm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            this.Close();
        }
    }
}
