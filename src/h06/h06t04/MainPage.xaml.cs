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
using Windows.UI.Popups;

namespace H06T04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            // Initializing all values to zero.
            widthTextBox.Text = "0";
            heightTextBox.Text = "0";
            frameWidthTextBox.Text = "0";
            windowAreaTextBox.Text = "0";
            windowClassAreaTextBox.Text = "0";
            framePerimeterLengthTextBox.Text = "0";
        }

        private void doCalculation(object sender, RoutedEventArgs e)
        {
            double width;
            double height;
            double frameWidth;

            // Trying to parse inputs as double.
            bool isWidthOk = double.TryParse(widthTextBox.Text, out width);
            bool isHeightOk = double.TryParse(heightTextBox.Text, out height);
            bool isFrameWidthOk = double.TryParse(frameWidthTextBox.Text, out frameWidth);

            // Checking that all inputs are correct. If whichever is not, show error.
            if (checkNumbers(isWidthOk, isHeightOk, isFrameWidthOk))
            {
                windowAreaTextBox.Text = calculateArea(width, height).ToString("0") + " cm^2";
                windowClassAreaTextBox.Text = calculateArea(width - frameWidth * 2, height - frameWidth * 2).ToString("0") + " cm^2";
                framePerimeterLengthTextBox.Text = calculatePerimeter(width, height).ToString("0") + " cm";
            }
        }

        private bool checkNumbers (bool w, bool h, bool fh)
        {
            if (!w)
            {
                showError("Ikkunan leveys ei kelpaa!");
                return false;
            }
            else if (!h)
            {
                showError("Ikkunan korkeus ei kelpaa!");
                return false;
            }
            else if (!fh)
            {
                showError("Karmin leveys ei kelpaa!");
                return false;
            }
            return true;
        }

        private async void showError (string text)
        {
            var dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }

        private double calculateArea(double w, double h)
        {
            return w * h;
        }

        private double calculatePerimeter (double w, double h)
        {
            return w * 2 + h * 2;
        }
    }
}
