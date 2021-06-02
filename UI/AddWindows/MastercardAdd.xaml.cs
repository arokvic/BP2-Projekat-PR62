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
    /// Interaction logic for MastercardAdd.xaml
    /// </summary>
    public partial class MastercardAdd : Window
    {
        public List<string> Cnames = new List<string>();
        bool check;
        long id;

        public MastercardAdd(Mastercard f)
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

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                if (numberTxt.Text != "" && cmbC.Text != "")
                {
                    if (int.TryParse(numberTxt.Text, out _))
                    {
                        Mastercard f = new Mastercard()
                        {
                            AccountNumber = Int64.Parse(numberTxt.Text),
                            CustomerJMBG = Int64.Parse(cmbC.Text)

                        };

                        MastercardCRUD fc = new MastercardCRUD();

                        if (fc.InsertMastercard(f))
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
                if (numberTxt.Text != "" && cmbC.Text != "")
                {

                    Mastercard f = new Mastercard()
                    {
                        AccountNumber = Int64.Parse(numberTxt.Text),
                        CustomerJMBG = Int64.Parse(cmbC.Text)

                    };
                    MastercardCRUD fc = new MastercardCRUD();

                    //List<Factory> l = fc.GetFactoryList();

                    if (fc.UpdateMastercard(f, id))
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
