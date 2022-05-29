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

        TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext();
        public Ticket ticket;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cboxClient.ItemsSource = db.Clients.ToList();
            cboxClient.DisplayMemberPath = "ClientName";
            cboxClient.SelectedValuePath = "Id";
            cboxClient.SelectedIndex = -1;

            cboxEmployee.ItemsSource = db.Employees.ToList();
            cboxEmployee.DisplayMemberPath = "Login";
            cboxEmployee.SelectedValuePath = "Id";
            cboxEmployee.SelectedIndex = -1;

            cboxStatus.ItemsSource = db.TicketsStatuses.ToList();
            cboxStatus.DisplayMemberPath = "TicketStatus";
            cboxStatus.SelectedValuePath = "Id";
            cboxStatus.SelectedIndex = -1;

            if (ticket != null && ticket.Id != 0)
            {
                txtTittle.Text = ticket.TicketTittle;
                txtContent.Text = ticket.TicketContent;
                cboxClient.SelectedValue = ticket.Id;
                cboxEmployee.SelectedValue = ticket.Id;
                cboxStatus.SelectedValue = ticket.Id;
                dpickDate.SelectedDate = ticket.TicketStartDate;
            }
        }

           private void btnSaveTicket_Click(object sender, RoutedEventArgs e)
            {
                if (string.IsNullOrEmpty(txtTittle.Text) || string.IsNullOrEmpty(txtContent.Text) ||
                    cboxClient.SelectedIndex == -1 || cboxEmployee.SelectedIndex == -1 || cboxEmployee.SelectedIndex == -1)
                {
                    MessageBox.Show("Please fill all inputs");
                }
                else 
                {
                    if ((ticket != null && ticket.Id != 0))
                    {
                    Ticket t = db.Tickets.Find(ticket.Id);
                    t.ClientId = (int)cboxClient.SelectedValue;
                    t.SatusId = (int)cboxStatus.SelectedValue;
                    t.EmployeeId = (int)cboxEmployee.SelectedValue;
                    t.TicketStartDate = (DateTime)dpickDate.SelectedDate;
                    t.TicketTittle = txtTittle.Text;
                    t.TicketContent = txtContent.Text;
                    db.SaveChanges();
                    MessageBox.Show($"Ticket {ticket.Id} has been updated");
                    }

                    else
                    {
                    Ticket ticket = new Ticket();
                    ticket.TicketTittle = txtTittle.Text;
                    ticket.TicketContent = txtContent.Text;
                    ticket.ClientId = (int)cboxClient.SelectedValue;
                    ticket.SatusId = (int)cboxStatus.SelectedValue;
                    ticket.EmployeeId = (int)cboxEmployee.SelectedValue;
                    ticket.TicketStartDate = (DateTime)dpickDate.SelectedDate;
                    db.Tickets.Add(ticket);
                    db.SaveChanges();
                    MessageBox.Show($"Ticket id: {ticket.Id} has been added");
                    txtTittle.Clear();
                    txtContent.Clear();
                    cboxClient.SelectedIndex = -1;
                    cboxEmployee.SelectedIndex = -1;
                    cboxStatus.SelectedIndex = -1;
                    dpickDate.SelectedDate = DateTime.Today;
                    }
                }

            }

        }

    
}
