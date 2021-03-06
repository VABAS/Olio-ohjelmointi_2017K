using System;
using System.Collections.Generic;

namespace KeyRegisterApp
{
    /// <summary>
    /// Command Line Interface for KeyRegisterApp.
    /// </summary>
    public class CliApplication
    {
        private KeyRegister keyRegister;
        private SettingsHandler settingsHandler;
        private static string usage = "Usage: KeyRegisterApp.exe [command] [arguments]";
        private static string helpString =
                "\nAvailable commands:\n" +
                "\n  listkeys - Lists all keys in register\n" +
                "\n  keydetails [keyDbId] - Shows information about key\n" +
                "\n  addkey [keyArgs] - Adds new key to register\n" +
                "    Where keyArgs are any combination of\n" +
                "    identifier=[value], name=[value] and description=[value]\n" +
                "    However, identifier and name are required for new key.\n" +
                "\n  editkey [keyDbId] [keyArgs] - Modifies key\n" +
                "    Where keyArgs are any combination of\n" +
                "    identifier=[value], name=[value] and description=[value]\n" +
                "    Any field value left out is considered not edited.\n" +
                "\n  setkeymissing [keyDbId] - Sets key to missing\n" +
                "\n  removekey [keyDbId] - Removes key from register\n" +
                "\n  loankey [keyDbId] [loanArgs] - Adds new loan for key\n" +
                "    Where loanArgs are any combination of\n" +
                "    datestart=[YYYY-mm-dd], datedue=[YYYY-mm-dd], loanedto=[value], isreturned=[true/false] and additional=[value]\n" +
                "    Only datestart must be provided.\n" +
                "\n  addloan - alias for loankey.\n" +
                "\n  listloans- lists all loans\n" +
                "\n  loandetails [loanDbId] - Shows details about loan\n" +
                "\n  editloan [loanDbId] [loanArgs] - Modifies loan\n" +
                "    Where loanArgs are any combination of\n" +
                "    datestart=[YYYY-mm-dd], datedue=[YYYY-mm-dd], loanedto=[value], isreturned=[true/false] and additional=[value]\n" +
                "    Any field value left out is considered not edited.\n" +
                "\n  returnloan [loanDbId] - Sets loan returned\n" +
                "\n  help - Display information about available operations.\n";

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
        public void runCommand (string[] argv)
        {
            string command = argv [0];
            List<string> args = new List<string> (argv);
            args.RemoveAt (0);
            int dbId;
            switch (command) {
            ////////////////////
            // Key operations //
            ////////////////////
            case "listkeys":
                listKeys ();
                break;
            case "keydetails":
                if (int.TryParse(args[0], out dbId)) {
                    getKeyDetails (dbId);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "addkey":
                addKey (args);
                break;
            case "editkey":
                if (int.TryParse (args [0], out dbId)) {
                    args.RemoveAt (0);
                    editKey (dbId, args);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "setkeymissing":
                if (int.TryParse (args [0], out dbId)) {
                    try {
                        keyRegister.setKeyToMissingById (dbId);
                    }
                    catch (KeyRegister.KeyIdNotFoundException e) {
                        Console.WriteLine (e.Message);
                    }
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "removekey":
                if (int.TryParse (args [0], out dbId)) {
                    try {
                        keyRegister.deleteKeyById(dbId);
                    }
                    catch (KeyRegister.KeyIdNotFoundException e) {
                        Console.WriteLine (e.Message);
                    }
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "loankey":
            case "addloan":
                if (int.TryParse (args [0], out dbId)) {
                    args.RemoveAt (0);
                    addLoanToKey (dbId, args);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;

            /////////////////////
            // Loan operations //
            /////////////////////
            case "listloans":
                listLoans ();
                break;
            case "loandetails":
                if (int.TryParse(args[0], out dbId)) {
                    getLoanDetails (dbId);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "editloan":
                if (int.TryParse(args[0], out dbId)) {
                    args.RemoveAt (0);
                    editLoan (dbId, args);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "returnloan":
                if (int.TryParse(args[0], out dbId)) {
                    args.RemoveAt (0);
                    setLoanReturned (dbId);
                }
                else {
                    Console.WriteLine ("Provided id not parsable as integer!");
                }
                break;
            case "help":
                Console.WriteLine (usage + "\n" + helpString);
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
        /// <param name="args">Fields given as list of strings.</param>
        private void addKey(List<string> args)
        {
            args = parseKeyFields (args);
            if (args[0] != null && args[1] != null) {
                try {
                    keyRegister.addNewKey(args [0], false, args [1], args [2]);
                }
                catch (KeyRegister.KeyUniquenessException e) {
                    Console.WriteLine ("Could not add key: " + e.Message);
                }
            }
            else {
                Console.WriteLine ("New key is required to have at least identifier and name fields!");
            }
        }

        /// <summary>
        /// Edits with dbId specified by first argument. Second argument is list of strings representing
        /// the editable field values.
        /// </summary>
        /// <param name="args">Arguments as list of strings.</param>
        private void editKey (int id, List<string> args)
        {
            if (args.Count >= 1) {
                args = parseKeyFields (args);

                // Checking that there is some field to modify.
                if (args[0] == null && args[1] == null && args[2] == null) {
                    Console.WriteLine ("Nothing to modify. Exiting.");
                    return;
                }

                try {
                    keyRegister.modifyKeyById(id, args[0], args[1], args[2]);
                }
                catch (KeyRegister.KeyIdNotFoundException e) {
                    Console.Write (e.Message);
                }
            }
            else {
                Console.WriteLine ("Invalid argument count of " + args.Count +
                                   ". Command 'addkey' reguires at least id and one modifiable field value.");
            }
        }

        /// <summary>
        /// Adds the loan for specified keyId.
        /// </summary>
        /// <param name="id">Id of the key to add loan for.</param>
        /// <param name="args">Loan field values.</param>
        private void addLoanToKey (int id, List<string> args)
        {
            args = parseLoanFields (args);
            bool returned = false;
            if (bool.TryParse (args [3], out returned) || args [3] == null) {
                keyRegister.addLoan (id, args [0], args [1], args [2], returned, args [4]);
            }
            else {
                Console.WriteLine("Value of 'returned' field not parsable as boolean. Must be either true or false.");
            }
        }

        /// <summary>
        /// Parses the key fields in format field=value and returns them as list of strings. Return 
        /// array is formatted {identifier, name, description}. Any missing field is returned as null.
        /// </summary>
        /// <returns>The key fields as list of strings.</returns>
        /// <param name="args">Arguments given as list of strings.</param>
        private List<string> parseKeyFields(List<string> args) {
            List<string> returnValue = new List<string> { null, null, null };

            foreach (string arg in args)
            {
                string[] argArray = arg.Split ('=');
                if (argArray.Length == 2) {
                    switch (argArray[0])
                    {
                        case "identifier":
                        if (returnValue[0] == null) {
                            returnValue[0] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'identifier'. Ignoring.");
                        }
                        break;
                        case "name":
                        if (returnValue[1] == null) {
                            returnValue[1] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'name'. Ignoring.");
                        }
                        break;
                        case "description":
                        if (returnValue[2] == null) {
                            returnValue[2] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'description'. Ignoring.");
                        }
                        break;
                    }
                }
                else {
                    Console.WriteLine ("Invalid argument '" + arg + "' specified.");
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Parses the loan fields provided as parameters. Returns list of strings like
        /// {dateStart, dateEnd, loanedTo, isReturned, aditional}. Any missing field is set to
        /// <see cref="null"/>.
        /// </summary>
        /// <returns>
        /// The loan fields as list of strings like {dateStart, dateEnd, loanedTo, isReturned, aditional}.
        /// </returns>
        /// <param name="args">Arguments.</param>
        private List<string> parseLoanFields(List<string> args) {
            List<string> returnValue = new List<string> { null, null, null, null, null };
            foreach (string arg in args)
            {
                string[] argArray = arg.Split ('=');
                if (argArray.Length == 2) {
                    switch (argArray[0])
                    {
                    case "datestart":
                        if (returnValue[0] == null) {
                            returnValue[0] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'dateStart'. Ignoring.");
                        }
                        break;
                    case "datedue":
                    case "dateend":
                        if (returnValue[1] == null) {
                            returnValue[1] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'dateEnd'. Ignoring.");
                        }
                        break;
                    case "loanedto":
                        if (returnValue[2] == null) {
                            returnValue[2] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'loanedTo'. Ignoring.");
                        }
                        break;
                    case "isreturned":
                    case "returned":
                        if (returnValue[3] == null) {
                            returnValue[3] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'returned'. Ignoring.");
                        }
                        break;
                    case "additional":
                        if (returnValue[4] == null) {
                            returnValue[4] = argArray [1];
                        }
                        else {
                            Console.WriteLine ("Duplicate entry of field 'additional'. Ignoring.");
                        }
                        break;
                    }
                }
                else {
                    Console.WriteLine ("Invalid argument '" + arg + "' specified.");
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Lists loans in database.
        /// </summary>
        private void listLoans ()
        {
            foreach (Loan loan in keyRegister.getAllLoans())
            {
                Console.WriteLine ("[" + loan.LoanDbId + "] " + loan.KeyId + ": " + loan.Returned.ToString ());
            }
        }

        /// <summary>
        /// Gets information about loan with specified dbId.
        /// </summary>
        /// <param name="dbId">DbId of the loan to get.</param>
        private void getLoanDetails (int dbId)
        {
            try {
                Loan key = keyRegister.getLoanById (dbId);
                Console.Write(key.ToString());
            }
            catch (KeyRegister.LoanIdNotFoundException e) {
                Console.WriteLine (e.Message);
            }
        }

        private void editLoan(int id, List<string> args) {
            args = parseLoanFields (args);
            try {
                // Index 3-IsReturned cannot be provided to modify operation.
                keyRegister.modifyLoanById (id, args [0], args [1], args [2], args [4]);
            }
            catch (KeyRegister.LoanIdNotFoundException e) {
                Console.WriteLine (e.Message);
            }
        }
        private void setLoanReturned (int id) {
            try {
                keyRegister.setLoanReturned(id);
            }
            catch (KeyRegister.LoanIdNotFoundException e) {
                Console.WriteLine (e.Message);
            }
        }
    }
}

