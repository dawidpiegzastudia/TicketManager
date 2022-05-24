using System.Windows;
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
            DataContext = new EmployeeViewMmodel();
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TicketViewModel();
        }
    }
}
