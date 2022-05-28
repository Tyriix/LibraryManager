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
        public bool Confirm { get; set; }
        public MainWindow()
        {
            InitializeComponent();
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
        private void Draggable_Object_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
            {
                DragMove();
            }
        }
    }
}
