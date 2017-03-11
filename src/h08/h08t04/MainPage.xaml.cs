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
            
            // Checking temperature radio-button to be default checked.
            tempRadio.IsChecked = true;
            
            // Initializing new kiuas-object.
            kiuas = new Kiuas();
        }

        private void okClicked(object sender, RoutedEventArgs e)
        {
            float value;
            if (float.TryParse(valueTextBox.Text, out value))
            {
                // Checking which of the radio-buttons is checked. If none,
                // throwing NotImplementedException.
                if ((bool)tempRadio.IsChecked)
                {
                    // Changing the temperature value. If exception happens,
                    // telling user that value could not be changed.
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
                    // Changing the humidity value. If exception happens,
                    // telling user that value could not be changed.
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

            // Setting label texts to represent the kiuas-objects values.
            tempValLabel.Text = kiuas.Temperature.ToString();
            humValLabel.Text = kiuas.Humidity.ToString();
            
            // Setting valueTextBox to show zero.
            valueTextBox.Text = "0";
        }
        
        /// <summary>
        /// Called when back-button is clicked. Removes latest character from
        // valueTextBox if any are left.
        /// </summary>
        private void backClicked(object sender, RoutedEventArgs e)
        {
            string line = valueTextBox.Text;
            if (line.Length > 0)
            {
                line = line.Substring(0, line.Length - 1);
                valueTextBox.Text = line;
            }
        }

        /// <summary>
        /// Called when any of the buttons 0-9 or . is pressed. Adds caller-
        /// buttons text to valueTextBox.
        /// </summary>
        private void buttonClicked(object sender, RoutedEventArgs e)
        {
            hideInfoText();
            string buttonString = (((Button)sender).Content).ToString();
            valueTextBox.Text += buttonString;
        }

        /// <summary>
        /// Simplified method to show info-message. Sets it's content and shows
        /// it (sets to visible).
        /// </summary>
        private void showInfoMessage(string msg)
        {
            infoTextBlock.Text = msg;
            infoTextBlock.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Method to hide info-text. Increases code readability.
        /// </summary>
        private void hideInfoText()
        {
            infoTextBlock.Visibility = Visibility.Collapsed; // Hides info text.
        }
    }
}
