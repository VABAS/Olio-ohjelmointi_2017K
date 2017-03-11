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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace H08T03
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // Textbox for lotto row display to use inside scrollviewer.
        TextBox lottoBox = new TextBox();
        
        // Initializing new instance of lotto class.
        Lotto lotto = new Lotto();

        public MainPage()
        {
            this.InitializeComponent();

            // Setting lottoBox-textbox so that it accepts line-end characters
            // to start new line in it. Also setting it as read only.
            lottoBox.IsReadOnly = true;
            lottoBox.AcceptsReturn = true;
            
            // Putting lottoBox inside scrollViewer object.
            scrollViewer.Content = lottoBox;
        }

        /// <summary>
        /// Method called when draw-button is pressed.
        /// </summary>
        private void drawClicked(object sender, RoutedEventArgs e)
        {
            // Clearing input at first.
            clear();

            // Checking that input is parsable as integer. Showing error if not.
            int numRows;
            bool inputValid = int.TryParse(numDrawsTextBox.Text, out numRows);
            if (inputValid)
            {
                for (int i = 0; i < numRows; i++)
                {
                    // Saving row number to variable as string.
                    string rowNum = (i + 1).ToString();

                    // Adding leading zero to numbers below ten.
                    if (i < 9)
                    {
                        rowNum = "0" + rowNum;
                    }
                    
                    // Adding row to lottobox. Using lotto's generateRow method.
                    lottoBox.Text += "Row " + rowNum + ": " + lotto.generateRow() + Environment.NewLine;
                }
            }
            else
            {
                showError("Could not parse input! (int.TryParse failed)");
            }
        }

        /// <summary>
        /// Method called when clear-button is pressed.
        /// </summary>
        private void clearClicked(object sender, RoutedEventArgs e)
        {
            clear();
        }

        /// <summary>
        /// Method to clear the lottoBox text. Increases code readability.
        /// </summary>
        private void clear()
        {
            lottoBox.Text = "";
        }
        
        /// <summary>
        /// Simplified method to show pop up errors.
        /// </summary>
        private async void showError(string text)
        {
            var dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
