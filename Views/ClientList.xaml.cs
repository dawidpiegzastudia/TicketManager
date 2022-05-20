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
    /// Interaction logic for ClientList.xaml
    /// </summary>
    public partial class ClientList : UserControl
    {
        public ClientList()
        {
            InitializeComponent();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Client> list = db.Clients.ToList();
                gridClients.ItemsSource = list;
            }
        }

        private void btnAddClient_Click(object sender, RoutedEventArgs e)
        {
            ClientPage clientPage = new ClientPage();
            clientPage.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Client> list = db.Clients.ToList();
                gridClients.ItemsSource = list;
            }
        }
    }
}
