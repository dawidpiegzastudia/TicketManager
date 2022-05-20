﻿using System;
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
    /// Interaction logic for ClientPage.xaml
    /// </summary>
    public partial class ClientPage : Window
    {
        public ClientPage()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtCName.Text) || string.IsNullOrEmpty(txtCPost.Text) || 
                string.IsNullOrEmpty(txtCStreet.Text) || string.IsNullOrEmpty(txtCbuilding.Text) || string.IsNullOrEmpty(txtCCity.Text))
            {
                MessageBox.Show("Please fill all inputs");
            }
            else
            {
                using(TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                {
                    Client clt  = new Client();
                    clt.ClientName = txtCName.Text;
                    clt.PostCode = txtCPost.Text;
                    clt.Street = txtCStreet.Text;
                    clt.BuildingNumber = txtCbuilding.Text;
                    clt.City = txtCCity.Text;
                    db.Clients.Add(clt);
                    db.SaveChanges();
                    txtCName.Clear();
                    txtCPost.Clear();
                    txtCStreet.Clear();
                    txtCbuilding.Clear();   
                    txtCCity.Clear();
                    MessageBox.Show("Client has been added");
                }
            }
        }
    }
}