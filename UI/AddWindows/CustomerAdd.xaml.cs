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
    /// Interaction logic for CustomerAdd.xaml
    /// </summary>
    public partial class CustomerAdd : Window
    {
        long id;
        bool check;
        public CustomerAdd(Customer f)
        {
            if (f == null)
            {
                check = false;
                InitializeComponent();

            }
            else
            {

                InitializeComponent();
                nameTxt.Text = f.FirstName;
                lastnameTxt.Text = f.LastName;
                cmb.Text = f.Sex;
                JMBGtxt.Text = f.JMBG.ToString();
                id = f.JMBG;
               // JMBGtxt.IsHitTestVisible = false;
                JMBGtxt.IsReadOnly = true;
                addBtn.Content = "Update";
                check = true;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                if (nameTxt.Text != "" && lastnameTxt.Text != "" && cmb.Text != "" && JMBGtxt.Text != "")
                {
                    if (int.TryParse(JMBGtxt.Text, out _))
                    {
                        Customer f = new Customer()
                        {
                            FirstName = nameTxt.Text,
                            LastName = lastnameTxt.Text,
                            Sex = cmb.Text,
                            JMBG = long.Parse(JMBGtxt.Text)


                        };

                        CustomerCRUD fc = new CustomerCRUD();

                        if (fc.InsertCustomer(f))
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
                }else
                {
                    MessageBox.Show("Empty fields!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {

                if (nameTxt.Text != "" && lastnameTxt.Text != "" && cmb.Text != "" && JMBGtxt.Text != "")
                {
                    Customer f = new Customer()
                    {

                        FirstName = nameTxt.Text,
                        LastName = lastnameTxt.Text,
                        Sex = cmb.Text
                       // JMBG = long.Parse(JMBGtxt.Text)

                    };
                    CustomerCRUD fc = new CustomerCRUD();
                    //List<Factory> l = fc.GetFactoryList();

                    if (fc.UpdateCustomer(f, long.Parse(JMBGtxt.Text)))
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
