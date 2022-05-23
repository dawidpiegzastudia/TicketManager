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
    /// Interaction logic for EmployeeListView.xaml
    /// </summary>
    public partial class EmployeeListView : UserControl
    {
        public EmployeeListView()
        {
            InitializeComponent();
            using (TicketingSystemDatabaseContext db1 = new TicketingSystemDatabaseContext())
            {
                List<Employee> list1 = db1.Employees.ToList();
                gridEmployees.ItemsSource = list1;
            }
        }

        private void btnAddEmployee_Click(object sender, RoutedEventArgs e)
        {
            EmployeePage employeePage = new EmployeePage();
            employeePage.ShowDialog();
            using (TicketingSystemDatabaseContext db1 = new TicketingSystemDatabaseContext())
            {
                List<Employee> list1 = db1.Employees.ToList();
                gridEmployees.ItemsSource = list1;
            }

        }

        private void btnUpdateemployee_Click(object sender, RoutedEventArgs e)
        {
            Employee employee = (Employee)gridEmployees.SelectedItem;
            EmployeePage page = new EmployeePage();
            page.employee = employee;
            page.ShowDialog();
            using (TicketingSystemDatabaseContext db1 = new TicketingSystemDatabaseContext())
            {
                List<Employee> list1 = db1.Employees.ToList();
                gridEmployees.ItemsSource = list1;
            }
        }

        private void btnRemoveEmployee_Click(object sender, RoutedEventArgs e)
        {

            Employee employee = (Employee)gridEmployees.SelectedItem;

            if (MessageBox.Show($"Are you sure to delete {employee.Login}?", "Questions", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                var db = new TicketingSystemDatabaseContext();
                db.Remove(employee);
                db.SaveChanges();
                List<Employee> list1 = db.Employees.ToList();
                gridEmployees.ItemsSource = list1;
            }
        }
    }
}
