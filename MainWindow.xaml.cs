using System.Windows;
using TicketManager.Database;
using TicketManager.ViewModels;

namespace TicketManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientWievModel();

        }

        private void btnUsers_Click(object sender, RoutedEventArgs e)
        {
            if (UserPermission.IsAdmin == true)
            {
                DataContext = new EmployeeViewMmodel();
            }
            else
            {
                MessageBox.Show("Only available for the Admin role!");
            }        
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TicketViewModel();
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.Close();
            loginPage.ShowDialog();
        }
    }
}
