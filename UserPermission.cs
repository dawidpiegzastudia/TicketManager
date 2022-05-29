using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketManager
{
    public static class UserPermission
    {
        public static int Id { get; set; }
        public static string Login { get; set; }
        public static bool IsAdmin { get; set; } 
    }
}
