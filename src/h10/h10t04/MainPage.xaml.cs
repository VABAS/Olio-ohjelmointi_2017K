using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System.Threading;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace breakout
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ThreadPoolTimer PeriodicTimer;
        private Random rand;

        public MainPage()
        {
            this.InitializeComponent();
            rand = new Random();
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            TimeSpan period = TimeSpan.FromSeconds(1);
            PeriodicTimer = ThreadPoolTimer.CreatePeriodicTimer(ElapsedHander, period, DestroydHandler);
        }
        private async void ElapsedHander(ThreadPoolTimer timer)
        {
            // get random number
            double number = rand.NextDouble();
            // update UI
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
                () =>
                {
            // UI components can be accessed within this scope
            RandomNumberTextBlock.Text = "Random number : " + number.ToString("0.0000");
                });
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PeriodicTimer.Cancel();
        }
        private async void DestroydHandler(ThreadPoolTimer timer)
        {
            await Dispatcher.RunAsync(CoreDispatcherPriority.High,
            () =>
            {
        // UI components can be accessed within this scope.
        RandomNumberTextBlock.Text = "PeriodicApp Timer Stopped!";
            });
        }
    }
}
