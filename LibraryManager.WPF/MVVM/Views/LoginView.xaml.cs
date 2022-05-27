using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace LibraryManager.WPF.MVVM.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LoginView.xaml
    /// </summary>
    public partial class LoginView : UserControl
    {

        public LoginView()
        {
            InitializeComponent();
        }

        private void LogIn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=.\\SQLEXPRESS;Database=LibraryManagerDb;Trusted_Connection=True");
            try
            {
                if (con.State == ConnectionState.Closed)
                    con.Open();
                string query = "SELECT COUNT(1) FROM Librarians WHERE Username=@username AND Password=@password";
                SqlCommand com = new SqlCommand(query, con);
                com.CommandType = CommandType.Text;
                com.Parameters.AddWithValue("@username", userName.Text);
                com.Parameters.AddWithValue("@password", password.Password);

                int count = Convert.ToInt32(com.ExecuteScalar());
                Application.Current.Resources.Add("username", userName.Text);
                if(count == 1)
                {
                    MainWindow window = new MainWindow();
                    window.Show();
                    Application.Current.Windows[0].Close();
                }
                else
                {
                    MessageBox.Show("Username or password is incorrect");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
