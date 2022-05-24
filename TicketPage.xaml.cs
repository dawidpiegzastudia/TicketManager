using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using TicketManager.Database;

namespace TicketManager
{
    /// <summary>
    /// Interaction logic for TicketPage.xaml
    /// </summary>
    public partial class TicketPage : Window
    {
        public TicketPage()
        {
            InitializeComponent();
        }


        public Ticket ticket;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext();
            cboxStatus.ItemsSource = db.TicketsStatuses.ToList();
            cboxStatus.DisplayMemberPath = "TicketStatus";
            cboxStatus.SelectedValuePath = "Id";
            cboxStatus.SelectedIndex = -1;

            cboxClient.ItemsSource = db.Clients.ToList();
            cboxClient.DisplayMemberPath = "ClientName";
            cboxClient.SelectedValuePath = "Id";
            cboxClient.SelectedIndex = -1;

            cboxEmployee.ItemsSource = db.Employees.ToList();
            cboxEmployee.DisplayMemberPath = "Login";
            cboxEmployee.SelectedValuePath = "Id";
            cboxEmployee.SelectedIndex = -1;    
        }

        private void btnSaveTicket_Click(object sender, RoutedEventArgs e)
        {
            

            if (string.IsNullOrEmpty(txtTittle.Text) || cboxClient.SelectedIndex == -1 ||  cboxEmployee.SelectedIndex == -1
                || cboxStatus.SelectedIndex == -1)
            {
                MessageBox.Show("Please fill all inputs");
            }
            else
            {
                using (TicketingSystemDatabaseContext db5 = new TicketingSystemDatabaseContext())
                {
                    Ticket ticket = new Ticket();
                    ticket.TicketTittle = txtTittle.Text;
                    ticket.TicketContent = txtContent.Text;
                    ticket.SatusId = (int)cboxStatus.SelectedValue;
                    ticket.TicketStartDate = DateTime.Today;
                    ticket.ClientId = (int)cboxClient.SelectedValue;
                    ticket.EmployeeId = (int)cboxEmployee.SelectedValue;

                    db5.Add(ticket);
                    db5.SaveChanges();
                    MessageBox.Show("Ticket has been added");
                    txtTittle.Clear();
                    txtContent.Clear();
                    dpickDate.SelectedDate = DateTime.Today;
                }
            }
        }

        private void btnCancelTicket_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
