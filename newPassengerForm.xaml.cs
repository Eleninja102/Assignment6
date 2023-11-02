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
