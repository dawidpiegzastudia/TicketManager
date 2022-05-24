using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TicketManager.Database;

namespace TicketManager.Views
{
    /// <summary>
    /// Interaction logic for TicketListView.xaml
    /// </summary>
    public partial class TicketListView : UserControl
    {
        public TicketListView()
        {

            InitializeComponent();

            using (TicketingSystemDatabaseContext db6 = new TicketingSystemDatabaseContext())
            {
                List<Ticket> tickets = db6.Tickets.ToList();
                gridTickets.ItemsSource = tickets;
            }
        }

        private void btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            TicketPage employeePage = new TicketPage();
            employeePage.ShowDialog();
        }
    }
}
