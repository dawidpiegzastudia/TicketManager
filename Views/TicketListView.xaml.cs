using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketManager.Database;

namespace TicketManager.Views
{
    /// <summary>
    /// Interaction logic for TicketListView.xaml
    /// </summary>
    public partial class TicketListView : UserControl
    {
        TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext();
        List<Ticket> tickets = new List<Ticket>();
        public TicketListView()
        {
            InitializeComponent();
            tickets = db.Tickets.ToList();
            gridTickets.ItemsSource = tickets;
        }

        private void btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            TicketPage page = new TicketPage(); 
            page.ShowDialog();
            using (TicketingSystemDatabaseContext db1 = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list1 = db1.Tickets.ToList();
                gridTickets.ItemsSource = list1;
            }
        }

        private void btnUpdateTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = new Ticket();
            TicketPage page = new TicketPage();
            page.ticket = ticket;
            page.ShowDialog();
            using (TicketingSystemDatabaseContext db1 = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list1 = db1.Tickets.ToList();
                gridTickets.ItemsSource = list1;
            }
        }

        private void btnRemoveTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = (Ticket)gridTickets.SelectedItem;

            if (MessageBox.Show($"Are you sure to delete {ticket.Id}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var db = new TicketingSystemDatabaseContext();
                db.Remove(ticket);
                db.SaveChanges();
                List<Ticket> list1 = db.Tickets.ToList();
                gridTickets.ItemsSource = list1;
            }
        }
    }
}
