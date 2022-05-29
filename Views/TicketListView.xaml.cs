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

        public TicketListView()
        {
            InitializeComponent();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list = db.Tickets.ToList();
                gridTickets.ItemsSource = list;
            }
        }

        private void btnAddTicket_Click(object sender, RoutedEventArgs e)
        {
            TicketPage ticketPage = new TicketPage(); 
            ticketPage.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list = db.Tickets.ToList();
                gridTickets.ItemsSource = list;
            }
        }

        private void btnUpdateTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = (Ticket)gridTickets.SelectedItem;
            TicketPage ticketPage = new TicketPage();
            ticketPage.ticket = ticket;
            ticketPage.ShowDialog();       
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list = db.Tickets.ToList();
                gridTickets.ItemsSource = list;
            }
        }

        private void btnRemoveTicket_Click(object sender, RoutedEventArgs e)
        {
            Ticket ticket = (Ticket)gridTickets.SelectedItem;
            if (MessageBox.Show($"Are you sure to delete {ticket.Id}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                {
                    db.Remove(ticket);
                    db.SaveChanges();
                    List<Ticket> list = db.Tickets.ToList();
                    gridTickets.ItemsSource = list;
                }
            }
        }
    }
}
