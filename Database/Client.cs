using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManager.Database
{
    public partial class Client
    {
        public Client()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string ClientName { get; set; }
        public string PostCode { get; set; }
        public string Street { get; set; }
        public string BuildingNumber { get; set; }
        public string City { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
