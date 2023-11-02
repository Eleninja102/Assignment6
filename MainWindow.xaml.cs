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
using System.Xml.Linq;

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
           //frameSeatLayout.Source = new Uri("Boeing 767.xaml", UriKind.Relative);
        }


        private void cbFlightInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string selected = e.AddedItems[0].ToString();
            cbPassengerInfo.ItemsSource = planeControl.getPassengerName(selected);
            string name = planeControl.getPlaneName();
            if(name == "Boeing 767")
            {
                gdSeatLayoutAirbusA380.Visibility = Visibility.Collapsed;
                gdSeatLayoutBoeing767.Visibility = Visibility.Visible;
                setSeatColors(gdSeatLayoutBoeing767);
            }else if(name == "Airbus A380")
            {
                gdSeatLayoutBoeing767.Visibility = Visibility.Collapsed;
                gdSeatLayoutAirbusA380.Visibility = Visibility.Visible;
                setSeatColors(gdSeatLayoutAirbusA380);
            }
            cbPassengerInfo.IsEnabled = true;
        }

        private void setSeatColors(Grid gdName)
        {
            foreach (Label control in gdName.Children)
            {
                
                string color = planeControl.getSeatColor(control.Content.ToString());
                if (color == "blue")
                {
                    control.Background = Brushes.RoyalBlue;
                }
                else if (color == "red")
                {
                    control.Background = Brushes.Red;
                }
                else if (color == "green")
                {
                    control.Background = Brushes.Green;
                }
                
            }
        }

        private void cbPassengerInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                string selected = e.AddedItems[0].ToString();
                string name = planeControl.getPlaneName();
                if (name == "Boeing 767")
                {
                    setSeatColors(gdSeatLayoutBoeing767);
                    setSelectedSeatColor(gdSeatLayoutBoeing767, planeControl.getPassengerSeat(selected).ToString());
                }
                else if(name == "Airbus A380")
                {
                    setSeatColors(gdSeatLayoutAirbusA380);
                    setSelectedSeatColor(gdSeatLayoutAirbusA380, planeControl.getPassengerSeat(selected).ToString());

                }
                return;
            }
            txtSeatNumber.Text = "";
        }

        private void setSelectedSeatColor(Grid gdName, string seat)
        {
            foreach (Label control in gdName.Children)
            {
                if(control.Content.ToString() == seat)
                {
                    control.Background = Brushes.Green;
                    txtSeatNumber.Text = seat;
                    return;
                }

            }
        }

    }
}
