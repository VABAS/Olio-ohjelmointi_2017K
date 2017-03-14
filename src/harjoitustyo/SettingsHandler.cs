using System;
using System.IO;
using System.Collections.Generic;

namespace KeyRegisterApp
{
    public class SettingsHandler
    {
        private Dictionary<string, string> settingsDict;
        private string configFileLocation;

        public Dictionary<string, string> Settings {
            get {
                return settingsDict;
            }
            set {
                settingsDict = value;
                writeToFile ();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="settingsFile">Settings file location.</param>
        public SettingsHandler (string settingsFile)
        {
            settingsDict = new Dictionary<string, string>();
            // Setting default values.
            settingsDict.Add("RegisterType", "XML");
            settingsDict.Add("RegisterXmlFileLocation", "KeyRegister.xml");

            configFileLocation = settingsFile;
            if (File.Exists(settingsFile))
            {
                StreamReader file = new StreamReader (settingsFile);
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    if (line.Length > 0) {
                        string[] valuePair = line.Split (':');
                        try {
                            settingsDict.Add (valuePair [0], valuePair [1]);
                        } catch (ArgumentException) {
                            settingsDict [valuePair [0]] = valuePair [1];
                        }
                    }
                }
                file.Close ();
            }
            else
            {
                writeToFile ();
            }
            
        }

        /// <summary>
        /// Constructor for SettingsHandler with not config file location provided. Using default
        /// location which is equal to the running location.
        /// </summary>
        public SettingsHandler () : this ("KeyRegisterAppSettings.conf")
        { }

        /// <summary>
        /// Writes settings to file.
        /// </summary>
        private void writeToFile()
        {
            StreamWriter outFile = new StreamWriter (configFileLocation);
            foreach(KeyValuePair<string, string> valuePair in settingsDict)
            {
                outFile.WriteLine (valuePair.Key + ":" + valuePair.Value);
            }
            outFile.Close ();
        }
    }
}

