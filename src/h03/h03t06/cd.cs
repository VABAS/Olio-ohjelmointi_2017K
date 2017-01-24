using System;
namespace H03T06
{
    class CD
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
        public CD (string artist, string name, string genre, double price, Track[] songs)
        {
            Artist = artist;
            Name = name;
            Genre = genre;
            Price = price;
            this.songs = songs;
        }

        // Methods.
        public string getDetails ()
        {
            string strOfSongs = "";
            for (int i = 0; i < songs.Length; i++)
            {
                strOfSongs +=  " --- " + songs[i].getDetails() + "\n";
            }
            return "CD:\n" +
                   "-Artist: " + Artist +
                   "\n-Name: " + Name +
                   "\n-Genre: " + Genre +
                   "\n-Price: " + Price +
                   "\n-Songs:\n" + strOfSongs;
        }
    }
}
