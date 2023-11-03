using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The screen to add a new passenger
        /// </summary>
        private newPassengerForm? passengerForm;
        /// <summary>
        /// Creates the main window and everything in it 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public MainWindow()
        {

            try
            {
                InitializeComponent();
                planeControl.setDatabase();
                cbFlightInfo.ItemsSource = planeControl.getPlaneDetails();
                gdSeatLayoutBoeing767.Visibility = Visibility.Hidden;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// Gets the correct list of the planes and updates the grid and passenger list. Enables the screen
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbFlightInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                string selected = e.AddedItems[0].ToString();
                cbPassengerInfo.ItemsSource = planeControl.getPassengerName(selected);
                string name = planeControl.getPlaneName();
                if (name == "Boeing 767")
                {
                    gdSeatLayoutAirbusA380.Visibility = Visibility.Collapsed;
                    gdSeatLayoutBoeing767.Visibility = Visibility.Visible;
                    setSeatColors(gdSeatLayoutBoeing767);
                }
                else if (name == "Airbus A380")
                {
                    gdSeatLayoutBoeing767.Visibility = Visibility.Collapsed;
                    gdSeatLayoutAirbusA380.Visibility = Visibility.Visible;
                    setSeatColors(gdSeatLayoutAirbusA380);
                }
                cbPassengerInfo.IsEnabled = true;
                buttonAddPassenger.IsEnabled = true;
                buttonChangeSeat.IsEnabled = true;
                buttonRemovePassenger.IsEnabled = true;
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Updates all the seat colors to blue or red or green given the table. Passes all the label content 
        /// </summary>
        /// <param name="gdName"></param>
        /// <exception cref="Exception"></exception>
        private void setSeatColors(Grid gdName)
        {

            try
            {
                foreach (Label control in gdName.Children)
                {

                    string? color = planeControl.getSeatColor(control.Content.ToString());
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
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }
        /// <summary>
        /// Loads the list of passengers from the correct list 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbPassengerInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (e.AddedItems.Count > 0)
                {
                    string? selected = e.AddedItems[0]?.ToString();
                    string? name = planeControl.getPlaneName();
                    if (name == "Boeing 767")
                    {
                        setSeatColors(gdSeatLayoutBoeing767);
                        setSelectedSeatColor(gdSeatLayoutBoeing767, planeControl.getPassengerSeat(selected).ToString());
                    }
                    else if (name == "Airbus A380")
                    {
                        setSeatColors(gdSeatLayoutAirbusA380);
                        setSelectedSeatColor(gdSeatLayoutAirbusA380, planeControl.getPassengerSeat(selected).ToString());

                    }
                    return;
                }
                txtSeatNumber.Text = "";
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }

        /// <summary>
        /// Takes the grid and seat number and set the color green
        /// </summary>
        /// <param name="gdName">The onscreen grid</param>
        /// <param name="seat">The seat number</param>
        /// <exception cref="Exception"></exception>
        private void setSelectedSeatColor(Grid gdName, string seat)
        {

            try
            {
                foreach (Label control in gdName.Children)
                {
                    if (control.Content.ToString() == seat)
                    {
                        control.Background = Brushes.LimeGreen;
                        txtSeatNumber.Text = seat;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// When the new passenger button is pressed show a new form while leaving the old one
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonAddPassenger_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                passengerForm = new newPassengerForm();
                passengerForm.ShowDialog();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }

        }








        /// <summary>
        /// Takes the given error from the entire program and prints a message box with the error. Also creates a txt file
        /// </summary>
        /// <param name="sClass">The last class used</param>
        /// <param name="sMethod"> The last method used</param>
        /// <param name="sMessage">The last message error sent</param>
        private void HandleError(string sClass, string sMethod, string sMessage)
        {
            try
            {
                //Would write to a file or database here.
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception ex)
            {
                System.IO.File.AppendAllText("C:\\Error.txt", Environment.NewLine +
                                             "HandleError Exception: " + ex.Message);
            }
        }
    }
}
