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

namespace H09T05
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        // define storage file
        private Windows.Storage.StorageFile sampleFile;

        // constructor
        public MainPage()
        {
            this.InitializeComponent();

            // create or open file
            CreateOrOpenFile();
            // read content and show
            ReadFile();

            locationTexBlock.Text = "File location: " + Windows.Storage.ApplicationData.Current.LocalFolder.Path;
        }

        // create or open local file
        private async void CreateOrOpenFile()
        {
            Windows.Storage.StorageFolder storageFolder =
                Windows.Storage.ApplicationData.Current.LocalFolder;
            sampleFile =
                await storageFolder.CreateFileAsync("sample.txt", Windows.Storage.CreationCollisionOption.OpenIfExists);
        }

        // read and display file content
        private async void ReadFile()
        {
            myTextBlock.Text = await Windows.Storage.FileIO.ReadTextAsync(sampleFile);
        }

        // write a new line to file and update UI
        private async void myButton_Click(object sender, RoutedEventArgs e)
        {
            await Windows.Storage.FileIO.AppendTextAsync(sampleFile, myTextBox.Text + Environment.NewLine);
            myTextBlock.Text += myTextBox.Text + Environment.NewLine;
        }
    }
}
