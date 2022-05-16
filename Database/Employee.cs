using System;
using System.Collections.Generic;

#nullable disable

namespace TicketManager.Database
{
    public partial class Employee
    {
        public Employee()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public bool IsAdmin { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
