using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Collections.Generic;

namespace KeyRegisterApp
{
    /// <summary>
    /// Handles key register stored in XML-file. Derived from abstract
    /// <see cref="KeyRegister"/>-class.
    /// </summary>
    public class KeyRegisterXml : KeyRegister
    {
        private XmlNode root = null;
        private XmlDocument doc = null;
        private string path;

        /// <summary>
        /// Initializes a new instance of the <see cref="KeyRegisterXml"/>
        /// class. Takes path to the XML-file as parameter. Throws
        /// <see cref="System.IO.FileNotFoundException"/> if file could not be
        /// found. 
        /// </summary>
        /// <param name="path">Path to the XML-file to use as register storage.</param>
        public KeyRegisterXml (string path)
        {
            this.path = path;
            doc = new XmlDocument ();

            // If file doesn't already exist, create it with empty register skeleton.
            if (!File.Exists(path))
            {
                string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n" +
                             "<keyregister biggestKeyId=\"0\" biggestLoanId=\"0\">\n" +
                             "</keyregister>";
                doc.LoadXml (xml);
                writeToFile ();
            }

            // Load file from path to XmlDocument-object.
            doc.Load(path);
            root = doc.DocumentElement;
        }

        /// <summary>
        /// Adds Key object provided as attribute to register and writes back to
        /// file after that.
        /// </summary>
        /// <param name="Key">Key-object to add.</param>
        public override void addNewKey (Key key)
        {
            // Check unigueness constraint (identifier).
            try {
                getKeyByIdentifier(key.Identifier);
                throw new KeyUniquenessException ("Key with identifier " + key.Identifier +
                                                  " already exists. Add failed.");
            }
            catch (KeyIdentifierNotFoundException)
            {
                // Key with identifier not found, continuing.
            }

            // Create XmlElement of identifier.
            XmlElement newIdentifier = doc.CreateElement ("identifier");
            newIdentifier.InnerText = key.Identifier;
            
            // Create XmlElement of name.
            XmlElement newName = doc.CreateElement ("name");
            newName.InnerText = key.Name;
            
            // Create XmlElement of description.
            XmlElement newDescription = doc.CreateElement ("description");
            newDescription.InnerText = key.Description;

            // Create XmlElement of key and add previosly created elements as
            // its child.
            XmlElement newKey = doc.CreateElement ("key");
            newKey.AppendChild (newIdentifier);
            newKey.AppendChild (newName);
            newKey.AppendChild (newDescription);

            // Incrementing biggest id.
            incrementBiggestKeyId ();

            // Add attributes to key-element.
            newKey.SetAttribute ("id", getBiggestKeyId ().ToString ());
            newKey.SetAttribute ("lost", key.IsMissing.ToString ());
            root.InsertAfter (newKey, root.LastChild);

            // Write XML back to file.
            writeToFile ();
        }

        /// <summary>
        /// Deletes the key by specified id-attribute.
        /// </summary>
        /// <param name="id">Id of the key to delete.</param>
        public override void deleteKeyById (int id)
        {
            XmlNode keyToRemove = root.SelectSingleNode ("key[@id='" +
                                                         id.ToString () + "']");
            if (keyToRemove != null) {
                root.RemoveChild (keyToRemove);
                writeToFile ();
            } else {
                throw new KeyIdNotFoundException ("Key with identifier '" +  id +
                                                  "' could not be found.");
            }
        }

        /// <summary>
        /// Gets the data by identifier.
        /// </summary>
        /// <returns>The data by identifier.</returns>
        /// <param name="id">Id of the key.</param>
        public override Key getKeyById (int id)
        {
            XmlNode key = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
            if (key != null) {
                return new Key(int.Parse(key.Attributes.GetNamedItem("id").InnerText),
                               key["identifier"].InnerText,
                               Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
                               key["name"].InnerText,
                               key["description"].InnerText);
            } else {
                throw new KeyIdNotFoundException ("Key with identifier '" + id +
                                                  "' could not be found.");
            }
        }

        /// <summary>
        /// Gets all keys from register and returns them as array of <see cref="Key"/>-objects. 
        /// </summary>
        /// <returns>All keys as array of <see cref="Key"/>-objects.</returns>
        public override Key[] getAllKeys ()
        {
            List<Key> allKeys = new List<Key> ();
            IEnumerator ienum = root.GetEnumerator ();
            XmlNode key;
            while (ienum.MoveNext()) {
                key = (XmlNode)ienum.Current;
                if (key.Name != "key")
                {
                    continue;
                }
                try {
                    allKeys.Add(new Key(int.Parse(key.Attributes.GetNamedItem("id").InnerText),
                                        key["identifier"].InnerText,
                                        Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
                                        key["name"].InnerText,
                                        key["description"].InnerText));
                }
                catch (Key.IdTooShortException e)
                {
                    Console.WriteLine ("ERROR: " + e.ToString ());
                }
                catch(Key.NameTooShortException e)
                {
                    Console.WriteLine ("ERROR: " + e.ToString ());
                }
            }
            return allKeys.ToArray ();

        }

        /// <summary>
        /// Modifies key which has the given id. Any field value that is set to
        /// <see cref="null"/> is not modified. Throws
        /// <see cref="KeyIdNotFoundException"/>  if key with specified id was not
        /// found.
        /// </summary>
        /// <param name="id">Id of the key to modify.</param>
        /// <param name="identifier">Identifier field for the key.</param>
        /// <param name="name">Name field for the key.</param>
        /// <param name="description">Description field for the key.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws KeyIdNotFoundException if key with specified id was not found.
        /// </exception>
        public override void modifyKeyById (int id,
                                            string identifier,
                                            string name,
                                            string description)
        {
            // Check unigueness constraint (identifier).
            try {
                Key tempKey = getKeyByIdentifier(identifier);

                // Database id checked to prevent missfiring when own identifier is detected.
                if (tempKey.DbId != id)
                {
                    throw new KeyUniquenessException ();
                }
            }
            catch (KeyIdentifierNotFoundException)
            {
                // Key with identifier not found, continuing.
            }
            XmlNode key = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
            if (key != null) {
                if (identifier != null) {
                    key ["identifier"].InnerText = identifier;
                }
                if (name != null) {
                    key ["name"].InnerText = name;
                }
                if (description != null) {
                    key ["description"].InnerText = description;
                }
                writeToFile ();
            } else {
                throw new KeyIdNotFoundException ("Key with identifier '" +
                                                  id + "' could not be found.");
            }

        }

        /// <summary>
        /// Gets the data of key by its identifier and returns it as
        /// <see cref="Key"/>-object. Throws
        /// <see cref="KeyIdentifierNotFoundException"/> if key with specified id
        /// was not found.
        /// </summary>
        /// <returns><see cref="Key"/>-object for key of the specified identifier.</returns>
        /// <param name="identifier">Id of the key to get.</param>
        /// <exception cref="KeyIdentifierNotFoundException">
        /// Throws KeyIdentifierNotFoundException if key with specified id was not
        /// found.
        /// </exception>
        public override Key getKeyByIdentifier (string identifier)
        {
            IEnumerator ienum = root.GetEnumerator ();
            XmlNode key;
            while (ienum.MoveNext()) {
                key = (XmlNode)ienum.Current;

                // Checking that we are at key-node.
                if (key.Name != "key")
                {
                    continue;
                }
                if (key ["identifier"].InnerText.Equals (identifier)) {
                    return new Key(int.Parse(key.Attributes.GetNamedItem("id").InnerText),
                                   key["identifier"].InnerText,
                                   Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
                                   key["name"].InnerText,
                                   key["description"].InnerText);
                }
            }

            // If not returned earlier, lets throw an exception becouse identifier was not found then.
            throw new KeyIdentifierNotFoundException ("Key with identifier '" + identifier +
                                                      "' could not be found.");
        }

        /// <summary>
        /// Sets the key by specified id to missing. Throws
        /// <see cref="KeyIdNotFoundException"/> if key with specified id was not
        /// found.
        /// </summary>
        /// <param name="id">Id of the key.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws KeyIdNotFoundException if key was not found with specified id.
        /// </exception>
        public override void setKeyToMissingById (int id)
        {
            XmlNode key = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
            if (key != null) {
                key.Attributes.GetNamedItem ("lost").InnerText = "true";
            } else {
                throw new KeyIdNotFoundException ("Key with identifier '" + id +
                                                  "' could not be found.");
            }
            writeToFile ();
        }

        /// <summary>
        /// Sets the key by specified id to not missing. Throws
        /// <see cref="KeyIdNotFoundException"/> if key with specified id was not
        /// found.
        /// </summary>
        /// <param name="id">Id of the key.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws KeyIdNotFoundException if key was not found with specified id.
        /// </exception>
        public override void setKeyToNotMissingById (int id)
        {
            XmlNode key = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
            if (key != null) {
                key.Attributes.GetNamedItem ("lost").InnerText = "false";
            } else {
                throw new KeyIdNotFoundException ("Key with identifier '" + id +
                                                  "' could not be found.");
            }
            writeToFile ();
        }

        /// <summary>
        /// Checks that key with specified id exists. Returns <c>true</c> if so and <c>false</c> otherwise.
        /// </summary>
        /// <returns><c>true</c>, if key exists, <c>false</c> otherwise.</returns>
        /// <param name="id">Id which is checked.</param>
        public override bool keyExists (int id)
        {
            if (root.SelectSingleNode ("key[@id='" + id.ToString () + "']") != null)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Adds the loan that represents the given object to register.
        /// </summary>
        /// <param name="loan">Loan-object to add.</param>
        public override void addLoan (Loan loan)
        {
            // Checking uniqueness constraint.
            if (getActiveLoanByKeyId (loan.KeyId) != null)
            {
                throw new LoanUniquenessException ("Loan for key with database id of " +
                                                   loan.KeyId + " already exists! Add failed.");
            }

            // Checking key missing status.
            if (getKeyById(loan.KeyId).IsMissing)
            {
                throw new KeyNotLoanableException ("Cannot loan becouse key is missing!");
            }

            // Create XmlElement of keyId.
            XmlElement newKeyId = doc.CreateElement ("keyId");
            newKeyId.InnerText = loan.KeyId.ToString ();

            // Create XmlElement of dateStart.
            XmlElement newDateStart = doc.CreateElement ("dateStart");
            newDateStart.InnerText = loan.DateStart;

            // Create XmlElement of dateEnd.
            XmlElement newDateEnd = doc.CreateElement ("dateEnd");
            newDateEnd.InnerText = loan.DateEnd;

            // Create XmlElement of loanedTo.
            XmlElement newLoanedTo = doc.CreateElement ("loanedTo");
            newLoanedTo.InnerText = loan.LoanedTo;

            // Create XmlElement of additionalInformation.
            XmlElement newAddInfo = doc.CreateElement ("additionalInformation");
            newAddInfo.InnerText = loan.AdditionalInformation;

            // Create XmlElement of loan and add previosly created elements as
            // its child.
            XmlElement newLoan = doc.CreateElement ("loan");
            newLoan.AppendChild (newKeyId);
            newLoan.AppendChild (newDateStart);
            newLoan.AppendChild (newDateEnd);
            newLoan.AppendChild (newLoanedTo);
            newLoan.AppendChild (newAddInfo);

            // Incrementing biggest id.
            incrementBiggestLoanId ();

            // Add attributes to key-element.
            newLoan.SetAttribute ("id", getBiggestLoanId ().ToString ());
            newLoan.SetAttribute ("returned", loan.Returned.ToString ());
            root.InsertAfter (newLoan, root.LastChild);

            // Write XML back to file.
            writeToFile ();
        }

        /// <summary>
        /// Deletes the loan by id.
        /// </summary>
        /// <param name="id">Id of the loan to delete.</param>
        public override void deleteLoanById (int id)
        {
            XmlNode loanToRemove = root.SelectSingleNode ("loan[@id='" +
                                                          id.ToString () + "']");
            if (loanToRemove != null) {
                root.RemoveChild (loanToRemove);
                writeToFile ();
            } else {
                throw new LoanIdNotFoundException ("Loan with identifier '" + id +
                                                   "' could not be found.");
            }
        }

        /// <summary>
        /// Gets the loan by id. Throws <see cref="LoanIdNotFoundException"/> if loan with given id could
        /// not be found.
        /// </summary>
        /// <returns>The loan-object which has the given id.</returns>
        /// <param name="id">Id of the loan to return.</param>
        public override Loan getLoanById (int id)
        {
            XmlNode loan = root.SelectSingleNode ("loan[@id='" + id.ToString () + "']");
            if (loan != null) {
                string dateEnd = null;
                if (loan["dateEnd"].InnerText.Length > 0)
                {
                    dateEnd = loan["dateEnd"].InnerText;
                }
                return new Loan(int.Parse(loan["keyId"].InnerText),
                                loan["dateStart"].InnerText,
                                dateEnd,
                                loan["loanedTo"].InnerText,
                                Boolean.Parse(loan.Attributes.GetNamedItem("returned").InnerText),
                                loan["additionalInformation"].InnerText);
            } else {
                throw new LoanIdNotFoundException ("Loan with identifier '" +
                                                   id + "' could not be found.");
            }
        }

        /// <summary>
        /// Gets the active loan by key id. Returns null if no active loans for specified keyId could be
        /// found.
        /// </summary>
        /// <returns>The active loan by key id.</returns>
        /// <param name="keyId">Id of the key of which loan to get.</param>
        public override Loan getActiveLoanByKeyId (int keyId)
        {
            Loan loan = null;
            IEnumerator ienum = root.GetEnumerator ();
            XmlNode currentLoan;
            while (ienum.MoveNext()) {
                currentLoan = (XmlNode)ienum.Current;
                if (currentLoan.Name != "loan")
                {
                    continue;
                }
                bool returned = 
                    Boolean.Parse (currentLoan.Attributes.GetNamedItem ("returned").InnerText);

                if (int.Parse (currentLoan["keyId"].InnerText) == keyId &&
                    !returned)
                {
                    string dateEnd = null;
                    if (currentLoan["dateEnd"].InnerText.Length > 0) {
                        dateEnd = currentLoan ["dateEnd"].InnerText;
                    }
                    loan = new Loan(int.Parse (currentLoan.Attributes.GetNamedItem ("id").InnerText),
                                    keyId,
                                    currentLoan["dateStart"].InnerText,
                                    dateEnd,
                                    currentLoan["loanedTo"].InnerText,
                                    returned,
                                    currentLoan["additionalInformation"].InnerText);
                    break;
                }
            }
            return loan;
        }

        /// <summary>
        /// Gets all loans from register and returns them as array of <see cref="Loan"/>-objects. 
        /// </summary>
        /// <returns>All loans as array of <see cref="Loan"/>-objects.</returns>
        public override Loan[] getAllLoans ()
        {
            List<Loan> allLoans = new List<Loan> ();
            IEnumerator ienum = root.GetEnumerator ();
            XmlNode loan;
            while (ienum.MoveNext()) {
                loan = (XmlNode)ienum.Current;
                if (loan.Name != "loan")
                {
                    continue;
                }
                string dateEnd = null;
                if (loan["dateEnd"].InnerText != "")
                {
                    dateEnd = loan ["dateEnd"].InnerText;
                }
                try
                {
                    allLoans.Add(new Loan (int.Parse(loan.Attributes.GetNamedItem("id").InnerText),
                                           int.Parse(loan["keyId"].InnerText),
                                           loan["dateStart"].InnerText,
                                           dateEnd,
                                           loan["loanedTo"].InnerText,
                                           bool.Parse(loan.Attributes.GetNamedItem("returned").InnerText),
                                           loan["additionalInformation"].InnerText));
                }
                catch (Loan.InvalidDateException e)
                {
                    Console.WriteLine ("[WARNING] Invalid loan entry: '" + loan.InnerXml + "'\nTrace: " + e.ToString ());
                }
            }
            return allLoans.ToArray ();

        }
        
        /// <summary>
        /// Gets all active loans from register and returns them as array of <see cref="Loan"/>-objects. 
        /// </summary>
        /// <returns>All active loans as array of <see cref="Loan"/>-objects.</returns>
        public override Loan[] getAllActiveLoans ()
        {
            Loan[] loans = getAllLoans ();
            List<Loan> activeLoans = new List<Loan> ();

            foreach (Loan loan in loans)
            {
                if (!loan.Returned)
                {
                    activeLoans.Add (loan);
                }
            }
            return activeLoans.ToArray ();
        }

        /// <summary>
        /// Modifies the loan by id. Throws <see cref="LoanIdNotFoundException"/> if loan with specified
        /// id could not be found.
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="dateStart">Date start.</param>
        /// <param name="dateEnd">Date end.</param>
        /// <param name="loanedTo">Loaned to.</param>
        /// <param name="additional">Additional info.</param>
        public override void modifyLoanById (int id,
                                             string dateStart,
                                             string dateEnd,
                                             string loanedTo,
                                             string additional)
        {
            XmlNode loan = root.SelectSingleNode ("loan[@id='" + id.ToString () + "']");
            if (loan != null) {
                if (dateStart != null) {
                    loan ["dateStart"].InnerText = dateStart;
                }
                if (dateEnd != null) {
                    loan ["dateEnd"].InnerText = dateEnd;
                }
                if (loanedTo != null) {
                    loan ["loanedTo"].InnerText = loanedTo;
                }
                if (additional != null) {
                    loan ["additionalInformation"].InnerText = additional;
                }
                writeToFile ();
            } else {
                throw new LoanIdNotFoundException ("Loan with identifier '" + id +
                                                   "' could not be found.");
            }
        }

        /// <summary>
        /// Sets the loan returned. Throws <see cref="LoanIdNotFoundException"/> if loan with specified
        /// id could not be found.
        /// </summary>
        /// <param name="id">Id of the loan.</param>
        public override void setLoanReturned (int id)
        {
            XmlNode loan = root.SelectSingleNode ("loan[@id='" + id.ToString () + "']");
            if (loan != null)
            {
                loan.Attributes.GetNamedItem("returned").InnerText = "true";
                writeToFile ();
            } else {
                throw new LoanIdNotFoundException ("Loan with identifier '" + id +
                                                   "' could not be found.");
            }
        }

        ///////////////////////////////////////////////////////////////
        /// Private methods, only in use at this XML-implementation ///
        ///////////////////////////////////////////////////////////////

        /// <summary>
        /// Gets the biggest loan id in keyregister. Key with such id may or may not
        /// exists at the time.
        /// </summary>
        /// <returns>Id as integer that is currently marked biggest.</returns>
        private int getBiggestLoanId ()
        {
            return int.Parse (root.Attributes.GetNamedItem ("biggestLoanId").InnerText);
        }

        /// <summary>
        /// Increments the biggest loan id of the register by one.
        /// </summary>
        private void incrementBiggestLoanId ()
        {
            root.Attributes["biggestLoanId"].Value = (getBiggestLoanId() + 1).ToString();
        }


        /// <summary>
        /// Gets the biggest key id in keyregister. Key with such id may or may not
        /// exists at the time.
        /// </summary>
        /// <returns>Id as integer that is currently marked biggest.</returns>
        private int getBiggestKeyId ()
        {
            return int.Parse (root.Attributes.GetNamedItem ("biggestKeyId").InnerText);
        }

        /// <summary>
        /// Increments the biggest key id of the register by one.
        /// </summary>
        private void incrementBiggestKeyId ()
        {
            root.Attributes["biggestKeyId"].Value = (getBiggestKeyId() + 1).ToString();
        }

        /// <summary>
        /// Writes register XML back to file.
        /// </summary>
        private void writeToFile ()
        {
            writeToFile (path);
        }
        
        /// <summary>
        /// Writes register XML back to specified file.
        /// </summary>
        /// <param name="path">Path to the file to write.</param>
        private void writeToFile (string path)
        {
            doc.Save (path);
        }
    }
}

