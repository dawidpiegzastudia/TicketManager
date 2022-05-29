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
            Client client = (Client)gridClients.SelectedItem;
            ClientPage page = new ClientPage();
            page.client = client;
            page.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Client> list = db.Clients.ToList();
                gridClients.ItemsSource = list;
            }
        }

        private void btnRemoveClient_Click(object sender, RoutedEventArgs e)
        {
            Client client = (Client)gridClients.SelectedItem;
            if (MessageBox.Show($"Are you sure to delete {client.ClientName}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                {
                    db.Remove(client);
                    db.SaveChanges();
                    List<Client> list = db.Clients.ToList();
                    gridClients.ItemsSource = list;
                }
            }
        }
    }
}
