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
using System.Windows.Navigation;
using System.Windows.Shapes;
using UI.TableWindows;

namespace UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FctBtn_Click(object sender, RoutedEventArgs e)
        {
            FactoryTable ft = new FactoryTable();
            ft.ShowDialog();
        }

       

        private void CartBtn_Click(object sender, RoutedEventArgs e)
        {
            OnlineCartTable ct = new OnlineCartTable();
            ct.ShowDialog();
        }

        private void CustomerBtn_Click(object sender, RoutedEventArgs e)
        {
            CustomerTable ct = new CustomerTable();
            ct.ShowDialog();
        }

        private void BallBtn_Click(object sender, RoutedEventArgs e)
        {
            BallTable ct = new BallTable();
            ct.ShowDialog();
        }

        private void VisacardBtn_Click(object sender, RoutedEventArgs e)
        {
            VisacardTable ct = new VisacardTable();
            ct.ShowDialog();
        }

        private void OrderBtn_Click(object sender, RoutedEventArgs e)
        {
            OrderTable ct = new OrderTable();
            ct.ShowDialog();
        }

        private void MasterBtn_Click(object sender, RoutedEventArgs e)
        {
            MastercardTable ct = new MastercardTable();
            ct.ShowDialog();
        }

        private void JerseyBtn_Click(object sender, RoutedEventArgs e)
        {
            JerseyTable ct = new JerseyTable();
            ct.ShowDialog();
        }

        private void SneakersBtn_Click(object sender, RoutedEventArgs e)
        {
            SneakersTable ct = new SneakersTable();
            ct.ShowDialog();
        }
    }
}
