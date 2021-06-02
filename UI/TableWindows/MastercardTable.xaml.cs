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
    /// Interaction logic for MastercardTable.xaml
    /// </summary>
    public partial class MastercardTable : Window
    {
        public MastercardTable()
        {
            InitializeComponent();
            MastercardCRUD fc = new MastercardCRUD();
            dGrid.ItemsSource = fc.GetMastercardList();
        }

        private void InsertBtn_Click(object sender, RoutedEventArgs e)
        {
            MastercardAdd fa = new MastercardAdd(null);
            fa.ShowDialog();
            MastercardCRUD fc = new MastercardCRUD();
            dGrid.ItemsSource = fc.GetMastercardList();
        }

        private void UpdateBtn_Click(object sender, RoutedEventArgs e)
        {
            Mastercard f = (Mastercard)dGrid.SelectedItem;
            MastercardAdd fa = new MastercardAdd(f);
            fa.ShowDialog();
            MastercardCRUD fc = new MastercardCRUD();
            dGrid.ItemsSource = fc.GetMastercardList();
        }

        private void DeleteBtn_Click(object sender, RoutedEventArgs e)
        {
            MastercardCRUD fc = new MastercardCRUD();

            Mastercard f = (Mastercard)dGrid.SelectedItem;


            fc.DeleteMastercard(f.AccountNumber);
            dGrid.ItemsSource = fc.GetMastercardList();
        }
    }
}
