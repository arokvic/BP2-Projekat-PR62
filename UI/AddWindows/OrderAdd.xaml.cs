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
    /// Interaction logic for OrderAdd.xaml
    /// </summary>
    public partial class OrderAdd : Window
    {
        public List<string> Anames = new List<string>();
        public List<string> Cnames = new List<string>();
        public List<string> Onames = new List<string>();
        bool check;
        int id;

        public OrderAdd(Order f)
        {
            PaymentCardCRUD fc = new PaymentCardCRUD();
            CustomerCRUD cc = new CustomerCRUD();
            OnlineCartCRUD oc = new OnlineCartCRUD();

            List<PaymentCard> ff = fc.GetPaymentCardList();
            List<Customer> c = cc.GetCustomerList();
            List<OnlineCart> o = oc.GetOnlineCartList();
            foreach (var item in ff)
            {
                Anames.Add(item.AccountNumber.ToString());
            }
            foreach (var item in c)
            {
                Cnames.Add(item.JMBG.ToString());
            }
            foreach (var item in o)
            {
                Onames.Add(item.Id.ToString());
            }


            if (f == null)
            {

                InitializeComponent();
                cmbA.ItemsSource = Anames;
                cmbC.ItemsSource = Cnames;
                cmbO.ItemsSource = Onames;

                check = false;

                // cmbF.ItemsSource = fnames;
            }
            else
            {

                InitializeComponent();
                cmbA.ItemsSource = Anames;
                cmbC.ItemsSource = Cnames;
                cmbO.ItemsSource = Onames;
                odtxt.Text = f.OrderDate.ToShortDateString();
                adtxt.Text = f.ArrivalDate.ToShortDateString();
             //   pricetxt.Text = f.Price.ToString();
               
                cmbA.Text = f.PaymentCardAccountNumber.ToString();
                cmbC.Text = f.CustomerJMBG.ToString();
                cmbO.Text = f.OnlineCartId.ToString();
                id = f.Id;
                addBtn.Content = "Update";
                check = true;
            }
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            OnlineCartCRUD oc = new OnlineCartCRUD();
            List<OnlineCart> l = oc.GetOnlineCartList();
            double x= 0;
            DateTime d;
            DateTime dateValue = default(DateTime);
            if (!check)
            {







                if (odtxt.Text != "" && adtxt.Text != "" && cmbA.Text != "" && cmbO.Text != "" && cmbC.Text != "" )// && pricetxt.Text != "")
                {
                    if (DateTime.TryParse(odtxt.Text, out dateValue) && DateTime.TryParse(adtxt.Text, out dateValue))
                    {
                        foreach (var item in l)
                        {
                            if (Int32.Parse(cmbO.Text) == item.Id)
                                x = item.Price;

                        }

                        Order f = new Order()
                        {
                            
                            OrderDate = DateTime.Parse(odtxt.Text),
                            ArrivalDate = DateTime.Parse(adtxt.Text),
                           

                            PaymentCardAccountNumber = Int32.Parse(cmbA.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text),
                            OnlineCartId = Int32.Parse(cmbO.Text),
                            Price = x

                        };

                        OrderCRUD fc = new OrderCRUD();

                        if (fc.InsertOrder(f))
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
                        MessageBox.Show("Date format is mm.dd.yy !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {

                    MessageBox.Show("Empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                if (odtxt.Text != "" && adtxt.Text != "" && cmbA.Text != "" && cmbO.Text != "" && cmbC.Text != "" )//&& pricetxt.Text != "")
                {
                    if (DateTime.TryParse(odtxt.Text, out dateValue) && DateTime.TryParse(adtxt.Text, out dateValue))
                    {
                        Order f = new Order()
                        {
                            OrderDate = DateTime.Parse(odtxt.Text),
                            ArrivalDate = DateTime.Parse(adtxt.Text),
                            

                            PaymentCardAccountNumber = Int32.Parse(cmbA.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text),
                            OnlineCartId = Int32.Parse(cmbO.Text)

                        };
                        OrderCRUD fc = new OrderCRUD();
                        //List<Factory> l = fc.GetFactoryList();

                        if (fc.UpdateOrder(f, id))
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
                        MessageBox.Show("Date format is mm.dd.yy !", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                else
                {

                    MessageBox.Show("Empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }

            }
        }
    }
    }

