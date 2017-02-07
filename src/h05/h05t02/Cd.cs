using System.Collections.Generic;

namespace H05T02
{
    class Cd
    {
        // Member variables.
        private string artist;
        private string name;
        private string genre;
        private double price;
        private List<Track> songs;

        // Properties
        public string Artist {
            get { return artist; }
            set { artist = value; }
        }
        public string Name {
            get { return name; }
            set { name = value; }
        }
        public string Genre {
            get { return genre; }
            set { genre = value; }
        }
        public double Price {
            get { return price; }
            set { price = value; }
        }

        // Constructors.
        public Cd (string artist, string name, string genre, double price)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            this.songs = new List<Track>();
        }

        // Add song with existing object.
        public void AddTrack (Track track)
        {
            songs.Add(track);
        }
        
        // Add song with title and length in minutes and seconds.
        public void AddTrack (string title, int lengthMin, int lenthSec)
        {
            songs.Add(new Track(title, lengthMin, lenthSec));
        }
        
        // Add song with title and length in seconds.
        public void AddTrack (string title, int length)
        {
            songs.Add(new Track(title, length));
        }
        
        public override string ToString ()
        {
            // Fetching songs and comining them into one string.
            string strOfSongs = " --- No songs";
            if (songs.Count > 0)
            {
                strOfSongs = "";
                for (int i = 0; i < songs.Count; i++)
                {
                    strOfSongs +=  " --- " + songs[i].ToString() + "\n";
                }
            }
            return "CD:\n" +
                   "-Artist: " + Artist + "\n" +
                   "-Name: " + Name + "\n" +
                   "-Genre: " + Genre + "\n" +
                   "-Price: " + Price.ToString("n2") + "\n" +
                   "-Songs:\n" + strOfSongs;
        }
    }
}
