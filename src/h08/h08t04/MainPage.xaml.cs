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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace T08H04
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Kiuas kiuas;
        public MainPage()
        {
            this.InitializeComponent();
            tempRadio.IsChecked = true;
            kiuas = new Kiuas();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            float value;
            if (float.TryParse(valueTextBox.Text, out value))
            {
                if ((bool)tempRadio.IsChecked)
                {
                    try
                    {
                        kiuas.Temperature = value;
                    }
                    catch (Kiuas.TemperatureValueOutOfBoundsException kiuasEx)
                    {
                        showInfoMessage(kiuasEx.Message);
                    }
                }
                else if ((bool)humRadio.IsChecked)
                {
                    try
                    {
                        kiuas.Humidity = value;
                    }
                    catch (Kiuas.HumidityValueOutOfBoundsException kiuasEx)
                    {
                        showInfoMessage(kiuasEx.Message);
                    }
                }
                else
                {
                    throw new NotImplementedException("Property not implemented!");
                }
            }
            else
            {
                showInfoMessage("Could not parse value as float!");
            }
            tempValLabel.Text = kiuas.Temperature.ToString();
            humValLabel.Text = kiuas.Humidity.ToString();
            valueTextBox.Text = "0";
        }
        private void backClicked(object sender, RoutedEventArgs e)
        {
            string line = valueTextBox.Text;
            if (line.Length > 0)
            {
                line = line.Substring(0, line.Length - 1);
                valueTextBox.Text = line;
            }
        }

        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            hideInfoText();
            string buttonString = (((Button)sender).Content).ToString();
            valueTextBox.Text += buttonString;
        }

        private void showInfoMessage(string msg)
        {
            infoTextBlock.Text = msg;
            infoTextBlock.Visibility = Visibility.Visible;
        }

        private void hideInfoText()
        {
            infoTextBlock.Visibility = Visibility.Collapsed; // Hides info text.
        }
    }
}
