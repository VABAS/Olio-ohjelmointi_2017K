﻿using System;
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
    public sealed partial class Block : UserControl
    {
        public double LocationX { get; set; }

        // location in y
        public double LocationY { get; set; }
        public Block()
        {
            this.InitializeComponent();
            Width = 50;
            Height = 20;
        }
        /// <summary>
        /// Return Block's rect.
        /// </summary>
        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }
        /// <summary>
        /// Set location in Canvas.
        /// </summary>
        public void SetLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }
    }
}