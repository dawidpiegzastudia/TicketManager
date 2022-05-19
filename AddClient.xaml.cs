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
using System.Windows.Shapes;
using TicketManager.Database;

namespace TicketManager
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(tboxBuildingNumber.Text) || (string.IsNullOrEmpty(tboxCity.Text)) ||
                (string.IsNullOrEmpty(tboxName.Text)) || (string.IsNullOrEmpty(tboxPostcode.Text)) 
                || (string.IsNullOrEmpty(tboxStreet.Text)))
            {
                MessageBox.Show("Please fill all positions");
            }
            else
            {
                using(TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                {
                    Client clt = new Client();
                    clt.ClientName = tboxName.Text;
                    clt.PostCode =  tboxPostcode.Text;
                    clt.Street = tboxStreet.Text;
                    clt.BuildingNumber = tboxBuildingNumber.Text;
                    clt.City = tboxCity.Text;
                    db.SaveChanges();
                    MessageBox.Show("Client has been saved.");
                }
            }
        }

    }
}
