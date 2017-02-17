using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace H06T01
{
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void increaseTrucks(object sender, RoutedEventArgs e)
        {
            numTrucks.Text = (Int32.Parse(numTrucks.Text) + 1).ToString();
        }

        private void increaseCars(object sender, RoutedEventArgs e)
        {
            numCars.Text = (Int32.Parse(numCars.Text) + 1).ToString();
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            numTrucks.Text = "0";
            numCars.Text = "0";
        }
    }
}
