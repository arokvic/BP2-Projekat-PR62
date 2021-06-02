using DataBase;
using DataBase.CRUDOperations;
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
using UI.AddWindows;

namespace UI.TableWindows
{
    /// <summary>
    /// Interaction logic for CustomerTable.xaml
    /// </summary>
    public partial class CustomerTable : Window
    {
        public CustomerTable()
        {
            InitializeComponent();
            CustomerCRUD fc = new CustomerCRUD();
            dGrid.ItemsSource = fc.GetCustomerList();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerAdd fa = new CustomerAdd(null);
            fa.ShowDialog();
            CustomerCRUD fc = new CustomerCRUD();
            dGrid.ItemsSource = fc.GetCustomerList();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Customer f = (Customer)dGrid.SelectedItem;
            CustomerAdd fa = new CustomerAdd(f);
            fa.ShowDialog();
            CustomerCRUD fc = new CustomerCRUD();
            dGrid.ItemsSource = fc.GetCustomerList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerCRUD fc = new CustomerCRUD();

            Customer f = (Customer)dGrid.SelectedItem;


            fc.DeleteCustomer(f.JMBG);
            dGrid.ItemsSource = fc.GetCustomerList();
        }
    }
}
