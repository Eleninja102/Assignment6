using System;
using System.Reflection;
using System.Windows;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for newPassengerForm.xaml
    /// </summary>
    public partial class newPassengerForm : Window
    {
        /// <summary>
        /// What happens when the form is created and appears
        /// </summary>
        /// <exception cref="Exception"></exception>
        public newPassengerForm()
        {
            try
            {
                InitializeComponent();

            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }
        }

        /// <summary>
        /// What happens when the save button is pressed right now nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                this.Hide();
            }
            catch (Exception ex)
            {
                //Just throw the exception
                HandleError(MethodInfo.GetCurrentMethod().DeclaringType.Name, MethodInfo.GetCurrentMethod().Name, ex.Message);
            }
        }
        /// <summary>
        /// What happens when the cancel button is pressed right now nothing
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                this.Hide();
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
