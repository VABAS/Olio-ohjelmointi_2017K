using System;
namespace H03T04
{
    class Vehicle
    {
        // Member variables.
        private string name;
        private int    speed;
        private int    tyres;
        
        // Properties.
        public string Name {
            set { name = value; }
            get { return name;}
        }
        public int Speed {
            set { speed = value; }
            get { return speed;}
        }
        public int Tyres {
            set { tyres = value; }
            get { return tyres;}
        }
        
        // Methods.
        public void PrintData ()
        {
            Console.WriteLine(ToString());
        }
        override public string ToString ()
        {
            return "Name: " + name + "\nNopeus: " + speed + "\nRenkaat: " + tyres;
        }
    }
}