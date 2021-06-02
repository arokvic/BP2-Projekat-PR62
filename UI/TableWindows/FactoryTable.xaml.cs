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
    /// Interaction logic for FactoryTable.xaml
    /// </summary>
    public partial class FactoryTable : Window
    {
        public FactoryTable()
        {
            InitializeComponent();
            FactoryCRUD fc = new FactoryCRUD();
            dGrid.ItemsSource = fc.GetFactoryList();


        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            FactoryAdd fa = new FactoryAdd(null);
            fa.ShowDialog();
            FactoryCRUD fc = new FactoryCRUD();
            dGrid.ItemsSource = fc.GetFactoryList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            FactoryCRUD fc = new FactoryCRUD();
          
            Factory f = (Factory)dGrid.SelectedItem;
           
          
            fc.DeleteFactory(f.Id);
            dGrid.ItemsSource = fc.GetFactoryList();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Factory f = (Factory)dGrid.SelectedItem;
            FactoryAdd fa = new FactoryAdd(f);
            fa.ShowDialog();
            FactoryCRUD fc = new FactoryCRUD();
            dGrid.ItemsSource = fc.GetFactoryList();
        }
    }
}
