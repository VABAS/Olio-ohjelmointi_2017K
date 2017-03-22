using System;

namespace KeyRegisterApp
{
    public class CliApplication
    {
        KeyRegister keyRegister;
        SettingsHandler settingsHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRegisterApp.CliApplication"/> class.
        /// </summary>
        public CliApplication ()
        {
            settingsHandler = new SettingsHandler ();
            if (settingsHandler.Settings["RegisterType"].ToUpper() == "XML") {
                keyRegister = new KeyRegisterXml(settingsHandler.Settings["RegisterXmlFileLocation"]);
            }
            else
            {
                throw new SettingsHandler.InvalidSettingValue ("Invalid register type '" +
                                                               settingsHandler.Settings["RegisterType"] +
                                                               "' specified");
            }
        }

        /////////////////////
        //  Other Methods  //
        /////////////////////
        /// <summary>
        /// Runs specified command with specified arguments
        /// </summary>
        public void runCommand (string[] args)
        {
            string command = args [0];

            switch (command) {
            ////////////////////
            // Key operations //
            ////////////////////
            case "listkeys":
                listKeys ();
                break;
            case "keydetails":
                int dbId;
                if (int.TryParse(args[1], out dbId)) {
                    getKeyDetails (dbId);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "addkey":
                if (args.Length - 1 == 4) {
                    bool isMissing;
                    if (bool.TryParse (args [2], out isMissing)) {
                        addKey (args [1], isMissing, args [3], args [4]);
                    }
                    else {
                        Console.WriteLine("Invalid value for parameter 2 (Key.isMissing).");
                    }
                }
                else {
                    Console.WriteLine ("Invalid argument count of " + (args.Length - 1) +
                                       ". Command 'addkey' reguires exatly 4 arguments.");
                }
                break;
            case "editkey":
                // TODO
                break;
            case "removekey":
                // TODO
                break;
            case "loankey":
                // TODO
                break;

            /////////////////////
            // Loan operations //
            /////////////////////
            case "listloans":
                // TODO
                break;
            case "loandetails":
                // TODO
                break;
            case "addloan":
                // TODO
                break;
            case "editloan":
                // TODO
                break;
            case "returnloan":
                // TODO
                break;
            case "help":
                // TODO
                break;
            default:
                Console.WriteLine ("Unknown command");
                break;
            }
        }

        /// <summary>
        /// Lists keys in database.
        /// </summary>
        private void listKeys ()
        {
            foreach (Key key in keyRegister.getAllKeys())
            {
                Console.WriteLine ("[" + key.DbId + "] " + key.Identifier + ": " + key.Name);
            }
        }

        /// <summary>
        /// Gets information about key with specified dbId.
        /// </summary>
        /// <param name="dbId">DbId of the key to get.</param>
        private void getKeyDetails (int dbId)
        {
            try {
                Key key = keyRegister.getKeyById (dbId);
                Console.Write(key.ToString());
            }
            catch (KeyRegister.KeyIdNotFoundException e) {
                Console.WriteLine (e.Message);
            }
        }

        /// <summary>
        /// Adds new key to register with fields as provided in parameters.
        /// </summary>
        /// <param name="identifier">Identifier of the key.</param>
        /// <param name="isMissing">If set to <c>true</c> key is missing.</param>
        /// <param name="name">Name of the key.</param>
        /// <param name="description">Description for the key.</param>
        private void addKey(string identifier, bool isMissing, string name, string description)
        {
            try {
                keyRegister.addNewKey(identifier, isMissing, name, description);
            }
            catch (KeyRegister.KeyUniquenessException e) {
                Console.WriteLine ("Could not add key: " + e.Message);
            }
        }
    }
}

