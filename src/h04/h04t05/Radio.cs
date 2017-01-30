namespace H04T05
{
    class Radio
    {
        private bool isOn;
        private int maxVolume;
        private int volume;
        private double[] channelRange = new double[2];
        private double channel;
        
        public bool IsOn {
            get { return isOn; }
            set { isOn = value; }
        }
        public int Volume {
            get { return volume; }
            set {
                if (value >= 0 && value <= maxVolume) {
                    volume = value;
                }
            }
        }
        public double Channel {
            get { return channel; }
            set {
                if (value >= channelRange[0] && value <= channelRange[1]) {
                    channel = value;
                }
            }
        }
        
        // Contructor.
        public Radio (int maxVolume, double channelBot, double channelHigh)
        {
            this.maxVolume = maxVolume;
            this.channel = channelBot;
            this.channelRange[0] = channelBot;
            this.channelRange[1] = channelHigh;
        }
        
        // Overriding ToString().
        public override string ToString ()
        {
            string status;
            if (this.isOn)
            {
                status = "on";
            }
            else
            {
                status = "off";
            }
            return " Radio is " + status +
                   " Volume: " + this.volume +
                   " Channel: " + string.Format("{0:0.0}", this.channel);
        }
    }
}
