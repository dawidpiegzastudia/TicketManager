using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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

        private void btnUpdateClient_Click(object sender, RoutedEventArgs e)
        {
            Client clt = (Client)gridClients.SelectedItem;
            ClientPage page = new ClientPage();
            page.client = clt;
            page.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Client> list = db.Clients.ToList();
                gridClients.ItemsSource = list;
            }
        }

        private void btnRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            Client clt = (Client)gridClients.SelectedItem;

            if (MessageBox.Show($"Are you sure to delete {clt.ClientName}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var db = new TicketingSystemDatabaseContext();
                db.Remove(clt);
                db.SaveChanges();
                List<Client> list = db.Clients.ToList();
                gridClients.ItemsSource = list;
            }

        }


    }
}
