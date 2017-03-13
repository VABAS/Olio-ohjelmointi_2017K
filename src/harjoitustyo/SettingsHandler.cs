using System;
using System.IO;

namespace KeyRegisterApp
{
    public class SettingsHandler
    {
        private string configFileLocation;

        // Setting values.
        private string registerType = "XML";
        private string registerXmlFileLocation = "KeyRegister.xml";

        public string RegisterType {
            get { return registerType; }
            set {
                registerType = value;
            }
        }

        public string RegisterXmlFileLocation {
            get { return registerXmlFileLocation; }
            set {
                registerXmlFileLocation = value;
            }
        }

        public SettingsHandler (string settingsFile)
        {
            configFileLocation = settingsFile;
            if (File.Exists(settingsFile))
            {
                StreamReader file = new StreamReader (settingsFile);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] valuePair = line.Split (':');
                    if (valuePair[0] == "RegisterType")
                    {
                        RegisterType = valuePair [1];
                    }
                    else if (valuePair[0] == "RegisterXmlFileLocation")
                    {
                        RegisterXmlFileLocation = valuePair [1];
                    }
                    else
                    {
                        Console.WriteLine ("[WARNING] Unknown setting '" + valuePair [0] + "'");
                    }
                }
                file.Close ();
            }
            else
            {
                writeToFile ();
            }
            
        }

        public SettingsHandler () : this ("KeyRegisterAppSettings.conf")
        { }

        public void writeToFile()
        {
            string[,] configArray = {
                {"RegisterType", RegisterType},
                {"RegisterXmlFileLocation", RegisterXmlFileLocation},
            };

            StreamWriter outFile = new StreamWriter (configFileLocation);
            for (int i = 0; i < configArray.GetLength(0); i++)
            {
                outFile.WriteLine (configArray[i, 0] + ":" + configArray[i, 1]);
            }
            outFile.Close ();
        }

        // Exception classes.
        public class InvalidSettingValue : System.Exception
        {
            public InvalidSettingValue() : base() { }
            public InvalidSettingValue(string message) : base(message) { }
        }
    }
}

