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
            using (TicketingSystemDatabaseContext database = new TicketingSystemDatabaseContext())
            {

            }
        }

        private void btnTickets_Click(object sender, RoutedEventArgs e)
        {
            DataContext = new TicketViewModel();

        }
    }
}
