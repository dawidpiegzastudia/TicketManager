using System;
using System.Linq;
using System.Windows;
using TicketManager.Database;

namespace TicketManager
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext();

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(txtLogin.Text) && String.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please fill all inputs.");
            }
            else
            {
                Employee employee = db.Employees.FirstOrDefault(x => x.Login == txtLogin.Text && x.Password == txtPassword.Text);
                if (employee != null && employee.Id != 0)
                {
                    this.Visibility = Visibility.Collapsed;
                    MainWindow mainWindow = new MainWindow();
                    UserPermission.Id = employee.Id;
                    UserPermission.Login = employee.Login;
                    UserPermission.IsAdmin = employee.IsAdmin;
                    mainWindow.ShowDialog();

                }
                else
                {
                    MessageBox.Show("The login or password is incorrect!");
                }
            }
        }
    }
}
