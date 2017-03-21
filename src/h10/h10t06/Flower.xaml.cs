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

namespace H10T06
{
    public sealed partial class Flower : UserControl
    {
        public double LocationX { get; set; }
        public double LocationY { get; set; }

        public Flower()
        {
            this.InitializeComponent();
            Width = 200;
            Height = 200;
        }

        public void UpdateLocation()
        {
            SetValue(Canvas.LeftProperty, LocationX);
            SetValue(Canvas.TopProperty, LocationY);
        }

        public Rect GetRect()
        {
            return new Rect(LocationX, LocationY, Width, Height);
        }
    }
}
