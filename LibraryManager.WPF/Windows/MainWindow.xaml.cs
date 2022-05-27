using LibraryManager.Domain.Models;
using System.Windows;
using System.Windows.Input;

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

        private void Exit_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            this.Close();
        }
        private void Minimize_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = true;
            this.WindowState = WindowState.Minimized;
        }
        private void Draggable_Object_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
