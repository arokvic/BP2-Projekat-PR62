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
    /// Interaction logic for VisacardTable.xaml
    /// </summary>
    public partial class VisacardTable : Window
    {
        public VisacardTable()
        {
            InitializeComponent();
            VisacardCRUD fc = new VisacardCRUD();
            dGrid.ItemsSource = fc.GetVisacardList();
        }

        private void deleteBtn_Click(object sender, RoutedEventArgs e)
        {
            VisacardCRUD fc = new VisacardCRUD();

            Visacard f = (Visacard)dGrid.SelectedItem;


            fc.DeleteVisacard(f.AccountNumber);
            dGrid.ItemsSource = fc.GetVisacardList();
        }

        private void updateBtn_Click(object sender, RoutedEventArgs e)
        {
            Visacard f = (Visacard)dGrid.SelectedItem;
            VisacardAdd fa = new VisacardAdd(f);
            fa.ShowDialog();
            VisacardCRUD fc = new VisacardCRUD();
            dGrid.ItemsSource = fc.GetVisacardList();
        }

        private void insertBtn_Click(object sender, RoutedEventArgs e)
        {
            VisacardAdd fa = new VisacardAdd(null);
            fa.ShowDialog();
            VisacardCRUD fc = new VisacardCRUD();
            dGrid.ItemsSource = fc.GetVisacardList();
        }
    }
}
