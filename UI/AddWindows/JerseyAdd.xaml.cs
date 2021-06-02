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
    /// Interaction logic for JerseyAdd.xaml
    /// </summary>
    public partial class JerseyAdd : Window
    {
        public List<string> Fnames = new List<string>();
        public List<string> Cnames = new List<string>();
        public List<string> Onames = new List<string>();
        bool check;
        int id;

        public JerseyAdd(Jersey f)
        {
            FactoryCRUD fc = new FactoryCRUD();
            CustomerCRUD cc = new CustomerCRUD();
            OnlineCartCRUD oc = new OnlineCartCRUD();

            List<Factory> ff = fc.GetFactoryList();
            List<Customer> c = cc.GetCustomerList();
            List<OnlineCart> o = oc.GetOnlineCartList();
            foreach (var item in ff)
            {
                Fnames.Add(item.Id.ToString());
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
                cmbF.ItemsSource = Fnames;
                cmbC.ItemsSource = Cnames;
                cmbO.ItemsSource = Onames;

                check = false;

                // cmbF.ItemsSource = fnames;
            }
            else
            {

                InitializeComponent();
                cmbF.ItemsSource = Fnames;
                cmbC.ItemsSource = Cnames;
                cmbO.ItemsSource = Onames;
                nameTxt.Text = f.Name;
                pricetxt.Text = f.Price.ToString();
                clbtxt.Text = f.Club;
                cmb.Text = f.Size.ToString();
                cmbF.Text = f.FactoryId.ToString();
                cmbC.Text = f.CustomerJMBG.ToString();
                cmbO.Text = f.OnlineCartId.ToString();
                id = f.Id;
                addBtn.Content = "Update";
                check = true;
            }
        }

     

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                if (nameTxt.Text != "" && cmb.Text != "" && cmbF.Text != "" && cmbO.Text != "" && cmbC.Text != "" && pricetxt.Text != "" && clbtxt.Text!="")
                {
                    if (int.TryParse(pricetxt.Text, out _))
                    {


                        Jersey f = new Jersey()
                        {
                            Name = nameTxt.Text,
                            Price = Double.Parse(pricetxt.Text),
                            Size = Int32.Parse(cmb.Text),
                            FactoryId = Int32.Parse(cmbF.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text),
                            OnlineCartId = Int32.Parse(cmbO.Text),
                            Club = clbtxt.Text

                        };

                        JerseyCRUD fc = new JerseyCRUD();

                        if (fc.InsertJersey(f))
                        {
                            OnlineCartCRUD oc = new OnlineCartCRUD();
                            OnlineCart o = oc.GetOnlineCartById(f.OnlineCartId.Value);
                            o.Price += f.Price;
                            o.NumberOfArticles++;
                            oc.UpdateOnlineCart(o, o.Id);

                            OrderCRUD ordc = new OrderCRUD();
                            List<Order> l = ordc.GetOrderList();
                            foreach (var item in l)
                            {
                                if (item.OnlineCartId == o.Id)
                                {
                                    item.Price += f.Price;
                                    ordc.UpdateOrder(item, item.Id);
                                }
                            }

                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Unable to add entity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some textboxes have to be numbers!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }

                }
                else
                {

                    MessageBox.Show("Empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);

                }
            }
            else
            {
                if (nameTxt.Text != "" && cmb.Text != "" && cmbF.Text != "" && cmbO.Text != "" && cmbC.Text != "" && pricetxt.Text != "" && clbtxt.Text != "")
                {
                    if (int.TryParse(pricetxt.Text, out _))
                    {
                        Jersey f = new Jersey()
                        {
                            Name = nameTxt.Text,
                            Price = Double.Parse(pricetxt.Text),
                            Size = Int32.Parse(cmb.Text),
                            FactoryId = Int32.Parse(cmbF.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text),
                            OnlineCartId = Int32.Parse(cmbO.Text),
                            Club = clbtxt.Text

                        };
                        JerseyCRUD fc = new JerseyCRUD();
                        //List<Factory> l = fc.GetFactoryList();
                        Jersey ff = fc.GetJerseyById(id);
                        if (fc.UpdateJersey(f, id))
                        {
                            OnlineCartCRUD oc = new OnlineCartCRUD();
                            OnlineCart o = oc.GetOnlineCartById(f.OnlineCartId.Value);
                            o.Price += f.Price;
                            o.Price -= ff.Price;
                            oc.UpdateOnlineCart(o, o.Id);

                            OrderCRUD ordc = new OrderCRUD();
                            List<Order> l = ordc.GetOrderList();
                            foreach (var item in l)
                            {
                                if (item.OnlineCartId == o.Id)
                                {
                                    item.Price += f.Price;
                                    item.Price -= ff.Price;
                                    ordc.UpdateOrder(item, item.Id);
                                }
                            }

                            Close();
                        }
                        else
                        {
                            MessageBox.Show("Unable to add entity", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Some textboxes have to be numbers!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
