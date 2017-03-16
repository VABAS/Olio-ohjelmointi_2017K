using System;

namespace KeyRegisterApp
{
    public class CliApplication
    {
        KeyRegister keyRegister;
        SettingsHandler settingsHandler;

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
        public void runCommand (string command, string[] args)
        {
            switch (command) {
            ////////////////////
            // Key operations //
            ////////////////////
            case "listkeys":
                // TODO
                break;
            case "addkey":
                // TODO
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
            case "addloan":
                // TODO
                break;
            case "editloan":
                // TODO
                break;
            case "returnloan":
                // TODO
                break;
            }
        }
    }
}

