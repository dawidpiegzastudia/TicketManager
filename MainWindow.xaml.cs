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


        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }


        private void btnClients_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new ClientWievModel();
        }

        private void btnAdminPanel_Click(object sender, RoutedEventArgs e)
        {
            AdminWindow adminWindow = new AdminWindow();
            this.Close();
            adminWindow.Show();


        }
    }
}
