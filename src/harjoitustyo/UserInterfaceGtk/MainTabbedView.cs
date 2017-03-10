using System;
using Gtk;

//TODO: This may be completely useless class after all...
namespace KeyRegisterApp
{
    public class MainTabbedView : Notebook
    {   
        public MainTabbedView()
        {
            WidthRequest = 700;
            HeightRequest = 500;
        }
    }
}

