﻿using System;
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

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for newPassengerForm.xaml
    /// </summary>
    public partial class newPassengerForm : Window
    {
        public newPassengerForm()
        {
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }

        private void buttonCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
        }
    }
}
