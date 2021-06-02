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
    /// Interaction logic for OrderTable.xaml
    /// </summary>
    public partial class OrderTable : Window
    {
        public OrderTable()
        {
            InitializeComponent();
            OrderCRUD fc = new OrderCRUD();
            dGrid.ItemsSource = fc.GetOrderList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderCRUD fc = new OrderCRUD();

            Order f = (Order)dGrid.SelectedItem;


            fc.DeleteOrder(f.Id);
            dGrid.ItemsSource = fc.GetOrderList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Order f = (Order)dGrid.SelectedItem;
            OrderAdd fa = new OrderAdd(f);
            fa.ShowDialog();
            OrderCRUD fc = new OrderCRUD();
            dGrid.ItemsSource = fc.GetOrderList();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
           

            OrderAdd fa = new OrderAdd(null);
            fa.ShowDialog();
            OrderCRUD fc = new OrderCRUD();
            dGrid.ItemsSource = fc.GetOrderList();
        }
    }
}
