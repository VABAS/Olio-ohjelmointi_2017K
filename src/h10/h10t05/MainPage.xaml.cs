using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Input;
using Windows.UI.ViewManagement;
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
        // Game
        private Game game;

        // canvas Width and Height
        public static double CanvasWidth;
        public static double CanvasHeight;
        public MainPage()
        {
            this.InitializeComponent();
            // change the default startup mode
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            // specify the size width:800, height:600 window size
            ApplicationView.PreferredLaunchViewSize = new Size(800, 600);

            // canvas width and height (used in Ball and Paddle)
            CanvasWidth = MyCanvas.Width;
            CanvasHeight = MyCanvas.Height;

            // create and start game
            game = new Game(MyCanvas);
            game.StartGame();
        }
        private void MyCanvas_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            PointerPoint pointerPoint = e.GetCurrentPoint(this);
            game.paddle.Move(pointerPoint.Position.X);
        }
    }
}