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




                     OnlineCart f = new OnlineCart()
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


                
              
            
           
        }
    }
}
