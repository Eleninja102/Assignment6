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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Assignment6
{
    /// <summary>
    /// Interaction logic for Boeing_767.xaml
    /// </summary>
    public partial class Boeing_767 : Page
    {
        public Boeing_767()
        {
            InitializeComponent();
            foreach (Control control in gdSeatLayoutBoeing767.Children)
            {
                if (control is Label)
                {
                    string color = planeControl.getSeatColor(control.Name);
                    if (color == "blue")
                    {
                        control.Background = Brushes.RoyalBlue;
                    }else if(color == "red")
                    {
                        control.Background = Brushes.Red;
                    }
                    else if(color == "green"){
                        control.Background= Brushes.Green;
                    }
                }
            }
        }

        public void activePassenger(int seatNum)
        {
            foreach (Control control in gdSeatLayoutBoeing767.Children)
            {
                if(control.Name == "seat" + seatNum)
                {
                    control.Background = Brushes.Green;
                    return;
                }
            }
        }
    }
}
