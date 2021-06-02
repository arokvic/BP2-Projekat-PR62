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
    /// Interaction logic for BallTable.xaml
    /// </summary>
    public partial class BallTable : Window
    {
        public BallTable()
        {
            InitializeComponent();
            BallCRUD fc = new BallCRUD();
            dGrid.ItemsSource = fc.GetBallList();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            BallAdd fa = new BallAdd(null);
            fa.ShowDialog();
            BallCRUD fc = new BallCRUD();
            dGrid.ItemsSource = fc.GetBallList();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Ball f = (Ball)dGrid.SelectedItem;
            BallAdd fa = new BallAdd(f);
            fa.ShowDialog();
            BallCRUD fc = new BallCRUD();
            dGrid.ItemsSource = fc.GetBallList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            BallCRUD fc = new BallCRUD();

            Ball f = (Ball)dGrid.SelectedItem;

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
                    oc.UpdateOnlineCart(n, n.Id);
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




            fc.DeleteBall(f.Id);
            dGrid.ItemsSource = fc.GetBallList();
        }
    }
}
