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

namespace UI.AddWindows
{
    /// <summary>
    /// Interaction logic for OnlineCartAdd.xaml
    /// </summary>
    public partial class OnlineCartAdd : Window
    {
        int id;
        bool check;
        public OnlineCartAdd(OnlineCart oc)
        {

            id = oc.Id;
            if (oc == null)
            {
                check = false;
                InitializeComponent();

            }
            else
            {

                InitializeComponent();
               
                addBtn.Content = "Update";
                check = true;
            }

           
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {




            if (nameTxt.Text != "" )
            {

                OnlineCart f = new OnlineCart()
                {
                    NumberOfArticles = Int32.Parse(nameTxt.Text)

                };
                OnlineCartCRUD fc = new OnlineCartCRUD();

                //List<Factory> l = fc.GetFactoryList();

                if (fc.UpdateOnlineCart(f, id))
                {
                    Close();
                }
                else
                {
                    MessageBox.Show("Unable to add entity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {

                MessageBox.Show("Empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

            }



            /*    OnlineCart f = new OnlineCart()
               {
                       NumberOfArticles = 0,
                       Price = 0

               };

               OnlineCartCRUD fc = new OnlineCartCRUD();

               if (fc.InsertOnlineCart(f))
               {
                   Close();
               }
               else
               {
                   MessageBox.Show("Unable to add entity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
               }
            */





        }
    }
}
