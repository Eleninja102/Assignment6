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

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            planeControl.setDatabase();
            cbFlightInfo.ItemsSource = planeControl.getPlaneDetails();
        }


        private void cbFlightInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = e.AddedItems[0].ToString();
            cbPassengerInfo.ItemsSource = planeControl.getPassengerName(selected);
            cbPassengerInfo.IsEnabled = true;
        }

        private void cbPassengerInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string selected = e.AddedItems[0].ToString();
                txtSeatNumber.Text = planeControl.getPassengerSeat(selected).ToString();
                return;
            }
            txtSeatNumber.Text = "";
        }

    }
}
