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

// The User Control item template is documented at http://go.microsoft.com/fwlink/?LinkId=234236

namespace breakout
{
    public sealed partial class Paddle : UserControl
    {
        public double LocationX { set; get; }

        // location in y
        public double LocationY { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public Paddle()
        {
            this.InitializeComponent();
            Width = 100;
            Height = 20;
        }
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        /// <summary>
        /// Move paddle with mouse.
        /// </summary>
        /// <param name="x">mouse x position in canvas</param>
        public void Move(double x)
        {
            // paddle new location in x (center x mouse)
            LocationX = x - Width / 2;
            // move, set new left top
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
        // Debug:
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }


    }
}