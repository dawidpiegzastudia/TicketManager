using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TicketManager.Database;

namespace TicketManager.Views
{
    /// <summary>
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Employee> list = db.Employees.ToList();
                gridEmployees.ItemsSource = list;
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage = new EmployeePage();
            employeePage.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Employee> list = db.Employees.ToList();
                gridEmployees.ItemsSource = list;
            }

        }

        private void btnUpdateemployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)gridEmployees.SelectedItem;
            EmployeePage employeePage = new EmployeePage();
            employeePage.employee = employee;
            employeePage.ShowDialog();
            using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
            {
                List<Employee> list = db.Employees.ToList();
                gridEmployees.ItemsSource = list;
            }

        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)gridEmployees.SelectedItem;
            
            if (MessageBox.Show($"Are you sure to delete {employee.Login}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (employee.Id == UserPermission.Id)
                {
                    MessageBox.Show("This action is not allowed! This user is currently logged in!");
                }
                else if (employee.Login == "Piegzus95")
                {
                    MessageBox.Show("This action is not allowed! You cannot remove default user!");
                }
                else
                {
                    using (TicketingSystemDatabaseContext db = new TicketingSystemDatabaseContext())
                    {
                        db.Remove(employee);
                        db.SaveChanges();
                        List<Employee> list = db.Employees.ToList();
                        gridEmployees.ItemsSource = list;
                    }
                }
                }
            }
    }
}
