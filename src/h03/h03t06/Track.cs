using System;
namespace H03T06
{
    class Track
    {
        // Member variables.
        private string title;
        private int length;

        // Properties.
        public string Title {
            get { return title; }
            set { title = value; }
        }
        public int Length {
            get { return length; }
            set { length = value; }
        }

        // Contructor. Takes track title and length in seconds as parameter.
        public Track (string title, int length)
        {
            Title = title;
            Length = length;
        }
        // Second counctructor. Takes track title and lenth in minutes and
        // seconds separately as parameter.
        public Track (string title, int lengthMin, int lenthSec)
        {
            Title = title;
            Length = lengthMin * 60 + lenthSec;
        }

        // Methods.
        public string getDetails ()
        {
            int minutes = length / 60;
            int seconds = length - minutes * 60;
            string zero = "";
            // Adding zero in front of seconds if they are below 10 (one
            // digit) for nice display.
            if (seconds < 10)
            {
                zero = "0";
            }
            return "Name: " + title + " - " + minutes + ":" + zero + seconds;
        }
    }
}
