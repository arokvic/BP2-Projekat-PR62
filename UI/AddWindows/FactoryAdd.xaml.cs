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
    /// Interaction logic for FactoryAdd.xaml
    /// </summary>
    public partial class FactoryAdd : Window
    {
        bool check;
        int id;
        public FactoryAdd(Factory f)
        {
            if (f == null)
            {
                check = false;
                InitializeComponent();
                
            }
            else
            {

                InitializeComponent();
                nameTxt.Text = f.Name;
                cityTxt.Text = f.City;
                id = f.Id;
                addBtn.Content = "Update";
                check = true;
            }
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!check)
            {
                if (nameTxt.Text != "" && cityTxt.Text != "")
                {
                    Factory f = new Factory()
                    {
                        Name = nameTxt.Text,
                        City = cityTxt.Text

                    };

                    FactoryCRUD fc = new FactoryCRUD();

                    if (fc.InsertFactory(f))
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
            else
            {
                if (nameTxt.Text != "" && cityTxt.Text != "")
                {
                    Factory f = new Factory()
                    {
                        Name = nameTxt.Text,
                        City = cityTxt.Text

                    };
                    FactoryCRUD fc = new FactoryCRUD();
                    //List<Factory> l = fc.GetFactoryList();

                    if (fc.UpdateFactory(f, id))
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
