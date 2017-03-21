using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace H10T06
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private bool UpPressed;
        private bool LeftPressed;
        private bool RightPressed;
        private Flower flower;
        Random rand;
        Butterfly butterfly;
        DispatcherTimer timer;
        public MainPage()
        {
            this.InitializeComponent();
            rand = new Random();

            // key listeners
            Window.Current.CoreWindow.KeyDown += CoreWindow_KeyDown;
            Window.Current.CoreWindow.KeyUp += CoreWindow_KeyUp;
            butterfly = new Butterfly
            { };
            MyCanvas.Children.Add(butterfly);
            AddFlower();
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 125);
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void AddFlower ()
        {
            flower = new Flower();
            flower.LocationX = rand.Next((int)MyCanvas.Width);
            flower.LocationY = rand.Next((int)MyCanvas.Height);
            flower.UpdateLocation();
            MyCanvas.Children.Add(flower);
        }
        private void Timer_Tick(object sender, object e)
        {
            // move 
            if (UpPressed) butterfly.Move();
            // rotate
            if (LeftPressed) butterfly.Rotate(-1);
            if (RightPressed) butterfly.Rotate(1);

            // update
            butterfly.UpdateLocation();

            // collision
            CheckCollision();
        }
        private void CheckCollision()
        {
            Rect r1 = butterfly.GetRect();
            r1.Intersect(flower.GetRect());
            if (!r1.IsEmpty)
            {
                MyCanvas.Children.Remove(flower);
                AddFlower();
            }
        }
        /// <summary>
        /// Check if some keys are pressed.
        /// </summary>
        private void CoreWindow_KeyDown(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = true;
                    break;
                case VirtualKey.Left:
                    LeftPressed = true;
                    break;
                case VirtualKey.Right:
                    RightPressed = true;
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Check if some keys are released.
        /// </summary>
        private void CoreWindow_KeyUp(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.KeyEventArgs args)
        {
            switch (args.VirtualKey)
            {
                case VirtualKey.Up:
                    UpPressed = false;
                    break;
                case VirtualKey.Left:
                    LeftPressed = false;
                    break;
                case VirtualKey.Right:
                    RightPressed = false;
                    break;
                default:
                    break;
            }
        }
    }
}
