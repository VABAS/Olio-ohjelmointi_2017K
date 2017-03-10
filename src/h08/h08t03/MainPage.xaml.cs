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
        TextBox lottoBox = new TextBox();
        Lotto lotto = new Lotto();
        public MainPage()
        {
            this.InitializeComponent();

            lottoBox.IsReadOnly = true;
            lottoBox.AcceptsReturn = true;
            scrollViewer.Content = lottoBox;
        }

        private void drawClicked(object sender, RoutedEventArgs e)
        {
            clear();
            int numRows;
            bool inputValid = int.TryParse(numDrawsTextBox.Text, out numRows);
            if (inputValid)
            {
                for (int i = 0; i < numRows; i++)
                {
                    string rowNum = (i + 1).ToString();
                    if (i < 9)
                    {
                        rowNum = "0" + rowNum;
                    }

                    lottoBox.Text += "Row " + rowNum + ": " + lotto.generateRow() + Environment.NewLine;
                }
            }
            else
            {
                showError("Could not parse input! (int.TryParse failed)");
            }
        }

        private void clearClicked(object sender, RoutedEventArgs e)
        {
            clear();
        }

        private void clear()
        {
            lottoBox.Text = "";
        }
        private async void showError(string text)
        {
            var dialog = new MessageDialog(text);
            await dialog.ShowAsync();
        }
    }
}
