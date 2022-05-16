using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManager.Database
{
    public partial class TicketsStatus
    {
        public TicketsStatus()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string TicketStatus { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
