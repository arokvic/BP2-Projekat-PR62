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
    /// Interaction logic for VisacardAdd.xaml
    /// </summary>
    public partial class VisacardAdd : Window
    {
        public List<string> Cnames = new List<string>();
        bool check;
        long id;

        public VisacardAdd(Visacard f)
        {
            CustomerCRUD cc = new CustomerCRUD();
            List<Customer> c = cc.GetCustomerList();
            foreach (var item in c)
            {
                Cnames.Add(item.JMBG.ToString());
            }

            if (f == null)
            {

                InitializeComponent();
               
                cmbC.ItemsSource = Cnames;
                

                check = false;

                // cmbF.ItemsSource = fnames;
            }
            else
            {

                InitializeComponent();
               
                cmbC.ItemsSource = Cnames;
              
                numberTxt.Text = f.AccountNumber.ToString();
               
                cmbC.Text = f.CustomerJMBG.ToString();
                
                id = f.AccountNumber;
                addBtn.Content = "Update";
                check = true;
                numberTxt.IsReadOnly = true;
            }


        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                if (numberTxt.Text != "" && cmbC.Text != null )
                {
                    if (int.TryParse(numberTxt.Text, out _))
                    {
                        Visacard f = new Visacard()
                        {
                            AccountNumber = Int64.Parse(numberTxt.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text)

                        };

                        VisacardCRUD fc = new VisacardCRUD();

                        if (fc.InsertVisacard(f))
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
                if (numberTxt.Text != "" && cmbC.Text != null)
                {

                    Visacard f = new Visacard()
                    {
                        AccountNumber = Int64.Parse(numberTxt.Text),
                        CustomerJMBG = Int64.Parse(cmbC.Text)

                    };
                    VisacardCRUD fc = new VisacardCRUD();

                    //List<Factory> l = fc.GetFactoryList();

                    if (fc.UpdateVisacard(f, id))
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

            }
        }
    }
    }

