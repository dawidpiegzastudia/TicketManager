using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManager.Database
{
    public partial class Ticket
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public int EmployeeId { get; set; }
        public string TicketTittle { get; set; }
        public string TicketContent { get; set; }
        public int SatusId { get; set; }
        public DateTime TicketStartDate { get; set; }

        public virtual Client Client { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual TicketsStatus Satus { get; set; }
    }
}
