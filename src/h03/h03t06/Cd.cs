using System;
namespace H03T06
{
    class Cd
    {
        // Member variables.
        private string artist;
        private string name;
        private string genre;
        private double price;
        private Track[] songs;

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

        // Constructor.
        public Cd (string artist, string name, string genre, double price, Track[] songs)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            this.songs = songs;
        }

        // Methods.
        public override string ToString ()
        {
            // Fetching songs and comining them into one string.
            string strOfSongs = "";
            for (int i = 0; i < songs.Length; i++)
            {
                strOfSongs +=  " --- " + songs[i].ToString() + "\n";
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
