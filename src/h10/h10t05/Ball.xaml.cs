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
    public sealed partial class Ball : UserControl
    {
        public double LocationX { get; set; }

        // location in y
        public double LocationY { get; set; }

        // speed in x
        public double XSpeed { get; set; }

        // speed in y
        public double YSpeed { get; set; }
        public Ball()
        {
            this.InitializeComponent();
            Width = 15;
            Height = 15;
            XSpeed = -4;
            YSpeed = -4;
        }
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }

        /// <summary>
        /// Move ball
        /// </summary>
        public void Move()
        {
            // change in x
            LocationX = LocationX + XSpeed;
            if (LocationX < 0)
            {
                LocationX = 0;
                XSpeed *= -1;
            }
            else if (LocationX + Width > MainPage.CanvasWidth)
            {
                LocationX = MainPage.CanvasWidth - Width;
                XSpeed *= -1;
            }

            // change in y
            LocationY = LocationY + YSpeed;
            if (LocationY < 0)
            {
                LocationY = 0;
                YSpeed *= -1;
            }

            // move, set new left top
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        /// <summary>
        /// Set speed to ball. Ball has collided with paddle.
        /// </summary>
        /// <param name="hitPercent">-0.5 to 0.5 value</param>
        public void SetSpeed(double hitPercent)
        {
            XSpeed = hitPercent * 10;
            YSpeed *= -1;
        }

        // Debug:
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}