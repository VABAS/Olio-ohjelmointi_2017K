using System;
using System.Xml;
using System.Collections;
using System.IO;
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
				string xml = "<?xml version=\"1.0\" encoding=\"UTF-8\" standalone=\"yes\"?>\n<keyregister biggestKeyId=\"0\" biggestLoanId=\"0\"></keyregister>";
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
			// TODO: Implement uniqueness constraint (Identifier).
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
				throw new KeyIdNotFoundException ("Key with identifier '" +
				                                  id + "' could not be found.");
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
				return new Key(key["identifier"].InnerText,
				               Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
				               key["name"].InnerText,
				               key["description"].InnerText);
			} else {
				throw new KeyIdNotFoundException ("Key with identifier '" +
				                                  id + "' could not be found.");
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
				allKeys.Add(new Key(key["identifier"].InnerText,
				            Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
		                    key["name"].InnerText,
		                    key["description"].InnerText));
			}
			return allKeys.ToArray ();

		}

		/// <summary>
		/// Modifies key which has the given id. Any field value that is set to
		/// <see cref="null"/> is not modified. Throws
		/// <see cref="KeyIdNotFoundException"/>  if key with specified id was not
		/// found.
		/// </summary>
		/// <param name="id">Id of the key to edit.</param>
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
			XmlNode key = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
			if (key != null) {
				if (identifier != null) {
					key ["identifier"].InnerText = identifier;
				}
				if (name != null) {
					key ["name"].InnerText = name;
				}
				if (name != null) {
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
				if (key ["identifier"].InnerText.Equals (identifier)) {
					return new Key(key["identifier"].InnerText,
					               Boolean.Parse(key.Attributes.GetNamedItem("lost").InnerText),
					               key["name"].InnerText,
					               key["description"].InnerText);
				}
			}

			// If not returned earlier, lets throw an exception because identifier was not found then.
			throw new KeyIdentifierNotFoundException ("Key with identifier '" +
			                                       identifier +
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
				throw new KeyIdNotFoundException ("Key with identifier '" +
				                               id + "' could not be found.");
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
				throw new KeyIdNotFoundException ("Key with identifier '" +
				                               id + "' could not be found.");
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

		public override void addLoan (Loan loan)
		{
			// TODO: Uniqueness constraint needs to be enforced. If there is already unreturned loan for
			// keyId, LoanUniquenessException must be raised.

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
			newLoan.SetAttribute ("lost", loan.Returned.ToString ());
			root.InsertAfter (newLoan, root.LastChild);

			// Write XML back to file.
			writeToFile ();
		}

		public override void deleteLoanById (int id)
		{
			XmlNode loanToRemove = root.SelectSingleNode ("loan[@id='" +
			                                              id.ToString () + "']");
			if (loanToRemove != null) {
				root.RemoveChild (loanToRemove);
				writeToFile ();
			} else {
				throw new LoanIdNotFoundException ("Loan with identifier '" +
				                                   id + "' could not be found.");
			}
		}

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

		public override void modifyLoanById (int id,
		                                     string dateStart,
		                                     string dateEnd,
		                                     string loanedTo,
		                                     string additional)
		{
			XmlNode loan = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
			if (loan != null) {
				if (dateStart != null) {
					loan ["identifier"].InnerText = dateStart;
				}
				if (dateEnd != null) {
					loan ["name"].InnerText = dateEnd;
				}
				if (loanedTo != null) {
					loan ["description"].InnerText = loanedTo;
				}
				if (additional != null) {
					loan ["description"].InnerText = additional;
				}
				writeToFile ();
			} else {
				throw new LoanIdNotFoundException ("Loan with identifier '" +
				                                   id + "' could not be found.");
			}
		}

		public override void setLoanReturned (int id)
		{
			XmlNode loan = root.SelectSingleNode ("key[@id='" + id.ToString () + "']");
			if (loan != null)
			{
				loan.Attributes.GetNamedItem("returned").InnerText = "true";
				writeToFile ();
			} else {
				throw new LoanIdNotFoundException ("Loan with identifier '" +
				                                   id + "' could not be found.");
			}
		}

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

		private void writeToFile (string path)
		{
			doc.Save (path);
		}
	}
}

