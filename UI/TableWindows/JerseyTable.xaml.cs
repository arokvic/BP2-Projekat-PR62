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
    /// Interaction logic for JerseyTable.xaml
    /// </summary>
    public partial class JerseyTable : Window
    {
        public JerseyTable()
        {
            InitializeComponent();
            JerseyCRUD fc = new JerseyCRUD();
            dGrid.ItemsSource = fc.GetJerseyList();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            JerseyAdd fa = new JerseyAdd(null);
            fa.ShowDialog();
            JerseyCRUD fc = new JerseyCRUD();
            dGrid.ItemsSource = fc.GetJerseyList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Jersey f = (Jersey)dGrid.SelectedItem;
            JerseyAdd fa = new JerseyAdd(f);
            fa.ShowDialog();
            JerseyCRUD fc = new JerseyCRUD();
            dGrid.ItemsSource = fc.GetJerseyList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            JerseyCRUD fc = new JerseyCRUD();

            Jersey f = (Jersey)dGrid.SelectedItem;

            OrderCRUD o = new OrderCRUD();
            List<Order> ol = o.GetOrderList();
            OnlineCartCRUD oc = new OnlineCartCRUD();
            List<OnlineCart> l = oc.GetOnlineCartList();
            foreach (var item in l)
            {
                if (item.Id == f.OnlineCartId)
                {
                    OnlineCart n = oc.GetOnlineCartById(item.Id);
                    n.Price -= f.Price;
                    n.NumberOfArticles--;
                    oc.UpdateOnlineCart(n,n.Id);
                    foreach (var item2 in ol)
                    {
                        if (item2.OnlineCartId == n.Id)
                        {
                            Order n2 = o.GetOrderById(item2.Id);
                            n2.Price -= f.Price;
                            o.UpdateOrder(n2, n2.Id);
                            break;
                        }
                    }

                }
            }
            
           



            fc.DeleteJersey(f.Id);
            dGrid.ItemsSource = fc.GetJerseyList();
        }
    }
}
