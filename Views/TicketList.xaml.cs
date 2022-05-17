using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using TicketManager.Database;

namespace TicketManager.Views
{
    /// <summary>
    /// Interaction logic for TicketList.xaml
    /// </summary>
    public partial class TicketList : UserControl
    {
        public TicketList()
        {
            InitializeComponent();

            using(TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Ticket> list = db.Tickets.ToList();
                gridTickets.ItemsSource = list;
            }

            
        }


    }
}
