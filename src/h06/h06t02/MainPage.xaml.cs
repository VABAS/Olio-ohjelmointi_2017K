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

namespace H06T02
{
    public sealed partial class MainPage : Page
    {
        // Initializing objects to null.
        private Car truck;
        private Car car;
        public MainPage()
        {
            this.InitializeComponent();

            // Creating instances of the car class.
            truck = new Car("Sisu");
            car = new Car("Audi");
            
            // Assigning button contents to represent the car-objects name-field.
            trucksButton.Content = truck.Name;
            carsButton.Content = car.Name;
        }

        // Incrementing truck count.
        private void truckClick(object sender, RoutedEventArgs e)
        {
            trucksTextBlock.Text = truck.add().ToString();
        }

        // Incrementing car count.
        private void carClick(object sender, RoutedEventArgs e)
        {
            carsTextBlock.Text = car.add().ToString();
        }

        // Clearing all clicks.
        private void clearClick(object sender, RoutedEventArgs e)
        {
            trucksTextBlock.Text = "0";
            carsTextBlock.Text = "0";
            truck.clear();
            car.clear();
        }
    }
}
