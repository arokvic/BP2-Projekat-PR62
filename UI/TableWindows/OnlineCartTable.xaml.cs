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
    /// Interaction logic for OnlineCartTable.xaml
    /// </summary>
    public partial class OnlineCartTable : Window
    {
        public OnlineCartTable()
        {
            InitializeComponent();
            OnlineCartCRUD fc = new OnlineCartCRUD();
            dGrid.ItemsSource = fc.GetOnlineCartList();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            //  OnlineCartAdd fa = new OnlineCartAdd(null);
            //  fa.ShowDialog();
            OnlineCart f = new OnlineCart()
            {
                NumberOfArticles = 0,
                Price = 0

            };

            OnlineCartCRUD fc = new OnlineCartCRUD();

            if (!fc.InsertOnlineCart(f)) { 
           
                MessageBox.Show("Unable to add entity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
           // OnlineCartCRUD fc = new OnlineCartCRUD();
            dGrid.ItemsSource = fc.GetOnlineCartList();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            OnlineCart f = (OnlineCart)dGrid.SelectedItem;
            OnlineCartAdd fa = new OnlineCartAdd(f);
            fa.ShowDialog();
            OnlineCartCRUD fc = new OnlineCartCRUD();
            dGrid.ItemsSource = fc.GetOnlineCartList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
           

            OnlineCartCRUD fc = new OnlineCartCRUD();

            OnlineCart f = (OnlineCart)dGrid.SelectedItem;


            fc.DeleteOnlineCart(f.Id);
            dGrid.ItemsSource = fc.GetOnlineCartList();

        }
    }
}
