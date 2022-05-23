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
    /// Interaction logic for EmployeePage.xaml
    /// </summary>
    public partial class EmployeePage : Window
    {
        public EmployeePage()
        {
            InitializeComponent();
        }
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Employee employee;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (employee != null && employee.Id != 0)
            {
                txtULogin.Text = employee.Login;
                txtUPassword.Text = employee.Password;
                txtUName.Text = employee.Name;
                txtUSurname.Text = employee.Surname;
                chckUAdmin.IsChecked = employee.IsAdmin;
            }
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtUName.Text) || string.IsNullOrEmpty(txtUPassword.Text) ||
                string.IsNullOrEmpty(txtUName.Text) || string.IsNullOrEmpty(txtUSurname.Text))
            {
                MessageBox.Show("Please fill all inputs");
            }
            else
            {
                using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                    if (employee != null && employee.Id != 0)
                {
                    Employee update = new Employee();
                    update.Id = employee.Id;
                    update.Login = txtULogin.Text;
                    update.Password = txtUPassword.Text;
                    update.Name = txtUName.Text;
                    update.Surname = txtUSurname.Text;
                    update.IsAdmin = (bool)chckUAdmin.IsChecked;
                    db.Update(update);
                    db.SaveChanges();
                    txtULogin.Clear();
                    txtUPassword.Clear();
                    txtUName.Clear();
                    txtUSurname.Clear();
                    chckUAdmin.IsChecked = false;
                    MessageBox.Show($"Employee {employee.Id} has been updated");
                }
                else
                {
                    Employee employee = new Employee();
                    employee.Id = employee.Id;
                    employee.Login = txtULogin.Text;
                    employee.Password = txtUPassword.Text;
                    employee.Name = txtUSurname.Text;
                    employee.Surname= txtUSurname.Text;
                    employee.IsAdmin = (bool)chckUAdmin.IsChecked;
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    txtULogin.Clear();
                    txtUPassword.Clear();
                    txtUName.Clear();   
                    txtUSurname.Clear();
                    chckUAdmin.IsChecked = false;
                    MessageBox.Show("Employee has been added");
                }
            }
        }
    }
}
