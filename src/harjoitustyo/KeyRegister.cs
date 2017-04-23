using System;

namespace KeyRegisterApp
{
    /// <summary>
    /// Class to handle key register operations. Classes for specific containers
    /// or databases should be serived from this class.
    /// </summary>
    public abstract class KeyRegister
    {
        /// <summary>
        /// Should be overridden at derived classes.
        /// </summary>
        public KeyRegister (){ }

        /// <summary>
        /// Get key by its id-attribute and return it as Key-object. Throws
        /// <see cref="KeyIdNotFoundException"/>  if key with given id could not be
        /// found.
        /// </summary>
        /// <returns>Key-object with specified id.</returns>
        /// <param name="id">Key id to get.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws KeyIdNotFoundException if key with given id could not be found.
        /// </exception>
        public abstract Key getKeyById(int id);

        /// <summary>
        /// Get key by its identifier-field and return as Key-object. Throws
        /// <see cref="KeyIdentifierNotFoundException"/> if key with given
        /// identifier could not be found.
        /// </summary>
        /// <returns>Key-object with specified identifier.</returns>
        /// <param name="id">Key identifier to get.</param>
        /// <exception cref="KeyIdentifierNotFoundException">
        /// Throws KeyIdentifierNotFoundException if key with given identifier
        /// could not be found.
        /// </exception>
        public abstract Key getKeyByIdentifier (string identifier);

        /// <summary>
        /// Gets all keys from register and returns them as array of <see cref="Key"/>-objects. 
        /// </summary>
        /// <returns>All keys as array of <see cref="Key"/>-objects.</returns>
        public abstract Key[] getAllKeys ();

        /// <summary>
        /// Adds Key object provided as attribue to register. Throws <see cref="KeyUniquenessException"/>  if uniqueness constraint fails.
        /// </summary>
        /// <param name="Key">Key-object to add.</param>
        /// <exception cref="KeyUniquenessException">Throws KeyUniquenessException if uniqueness constraint fails.</exception>
        public abstract void addNewKey (Key key);

        /// <summary>
        /// Adds the new key with specified values. Calls base method
        /// <see cref="addNewKey(Key key)"/> with created Key-object. 
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="isMissing">SPecifies that key is missing if set to <c>true</c>.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        public void addNewKey (string identifier,
                               bool isMissing,
                               string name,
                               string description)
        {
            addNewKey (new Key(identifier, isMissing, name, description));
        }

        /// <summary>
        /// Deletes the key by specified identifier. Throws
        /// <see cref="IdNotFounException"/> if key with specified id is not
        /// found.
        /// </summary>
        /// <param name="id">Id of the key to delete.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws <see cref="IdNotFounException"/> if key with specified id is
        /// not found.
        /// </exception>
        public abstract void deleteKeyById (int id);

        /// <summary>
        /// Modifies the key with given Id-parameter. Any field value that is
        /// set to <see cref="null"/> is not modified. Throws
        /// <see cref="KeyIdNotFoundException"/> if key with given id could not be
        /// found.
        /// </summary>
        /// <param name="id">Id-attribute of the key to edit.</param>
        /// <param name="identifier">Identifier-field value.</param>
        /// <param name="name">Name-field value.</param>
        /// <param name="description">Description-field value.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws KeyIdNotFoundException if key with fiven id could not be found.
        /// </exception>
        public abstract void modifyKeyById (int id, 
                                            string identifier,
                                            string name,
                                            string description);
        
        /// <summary>
        /// Sets key with specified id to missing. Throws
        /// <see cref="KeyIdNotFoundException"/> if key with given id could not be
        /// found. 
        /// </summary>
        /// <param name="id">If of the key to modify.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws <see cref="KeyIdNotFoundException"/> if key with given id could
        /// not be found.
        /// </exception>
        public abstract void setKeyToMissingById (int id);
        
        /// <summary>
        /// Sets key with specified id to not missing. Throws
        /// <see cref="KeyIdNotFoundException"/> if key with given id could not be
        /// found. 
        /// </summary>
        /// <param name="id">If of the key to modify.</param>
        /// <exception cref="KeyIdNotFoundException">
        /// Throws <see cref="KeyIdNotFoundException"/> if key with given id could
        /// not be found.
        /// </exception>
        public abstract void setKeyToNotMissingById (int id);

        /// <summary>
        /// Checks that key with specified id exists. Returns <c>true</c> if so and <c>false</c> otherwise.
        /// </summary>
        /// <returns><c>true</c>, if key exists, <c>false</c> otherwise.</returns>
        /// <param name="id">Id which is checked.</param>
        public abstract bool keyExists (int id);

        /// <summary>
        /// Gets the loan by its id and returns it as <see cref="Loan"/>-object. Throws <see cref="LoanIdNotFoundException"/> if loan with specified id could not be found
        /// </summary>
        /// <returns>The loan-object with specified identifier.</returns>
        /// <param name="id">Id of the loan to return.</param>
        /// <exception cref="LoanIdNotFoundException">Throws LoanIdNotFoundException if loan with specified id could not be found</exception>
        public abstract Loan getLoanById (int id);

        /// <summary>
        /// Gets the active loan by key id.
        /// </summary>
        /// <returns>The active loan by key identifier.</returns>
        /// <param name="keyId">Key identifier.</param>
        public abstract Loan getActiveLoanByKeyId (int keyId);

        /// <summary>
        /// Gets all loans from register and returns them as array of <see cref="Loan"/>-objects. 
        /// </summary>
        /// <returns>All loans as array of <see cref="Loan"/>-objects.</returns>
        public abstract Loan[] getAllLoans ();
        
        /// <summary>
        /// Gets all active loans from register and returns them as array of <see cref="Loan"/>-objects. 
        /// </summary>
        /// <returns>All loans as array of <see cref="Loan"/>-objects.</returns>
        public abstract Loan[] getAllActiveLoans ();

        /// <summary>
        /// Deletes the loan by id. Throws <see cref="LoanIdNotFoundException"/> if loan with specified id could not be found.
        /// </summary>
        /// <param name="id">Id of the loan to delete.</param>
        /// <exception cref="LoanIdNotFoundException">Throws LoanIdNotFoundException if loan with specified id could not be found.</exception>
        public abstract void deleteLoanById (int id);

        /// <summary>
        /// Modifies the loan by id. Any parameter set to <see cref="null"/> is not modified.  Throws <see cref="LoanIdNotFoundException"/> if loan with specified id could not be found
        /// </summary>
        /// <param name="id">Identifier.</param>
        /// <param name="dateStart">Date start.</param>
        /// <param name="dateEnd">Date end.</param>
        /// <param name="loanedTo">Loaned to.</param>
        /// <param name="additional">Additional.</param>
        /// <exception cref="LoanIdNotFoundException">Throws LoanIdNotFoundException if loan with specified id could not be found.</exception>
        public abstract void modifyLoanById (int id,
                                             string dateStart,
                                             string dateEnd,
                                             string loanedTo,
                                             string additional);

        /// <summary>
        /// Adds the loan that represents the given object to register. Keys loan status should be checked at overriding implementation.
        /// </summary>
        /// <param name="loan">Loan-object to add.</param>
        public abstract void addLoan (Loan loan);

        /// <summary>
        /// Adds new loan with specified parameters. Trows <see cref="LoanUniquenessException"/> if there is already unreturned loan for keyId.
        /// </summary>
        /// <param name="keyId">Id of the key to loan.</param>
        /// <param name="dateStart">Starting date of the loan.</param>
        /// <param name="dateEnd">Ending date of the loan.</param>
        /// <param name="loanedTo">To whom is key loaned to.</param>
        /// <param name="additional">Additional information about the loan.</param>
        /// <exception cref="LoanUniquenessException">Trows LoanUniquenessException if there is already unreturned loan for keyId.</exception>
        public void addLoan(int keyId,
                            string dateStart,
                            string dateEnd,
                            string loanedTo,
                            bool returned,
                            string additional)
        {
            addLoan (new Loan (keyId, dateStart, dateEnd, loanedTo, returned, additional));
        }

        /// <summary>
        /// Adds new loan with specified parameters. No dateEnd specified.
        /// </summary>
        /// <param name="keyId">Id of the key to loan.</param>
        /// <param name="dateStart">Starting date of the loan.</param>
        /// <param name="loanedTo">To whom is key loaned to.</param>
        /// <param name="additional">Additional information about the loan.</param>
        public void addLoan(int keyId,
                            string dateStart,
                            string loanedTo,
                            bool returned,
                            string additional)
        {
            addLoan (new Loan (keyId, dateStart, null, loanedTo, returned, additional));
        }

        /// <summary>
        /// Sets the loan with specified id returned. Throws <see cref="LoanIdNotFoundException"/>  if loan with specified id cannot be found.
        /// </summary>
        /// <param name="id">Id of the loan to set returned.</param>
        /// <exception cref="LoanIdNotFoundException">Trows LoanIdNotFoundException if loan with specified id cannot be found.</exception>
        public abstract void setLoanReturned (int id);

        // Exception classes.
        public class KeyIdNotFoundException : System.Exception
        {
            public KeyIdNotFoundException() : base() { }
            public KeyIdNotFoundException(string message) : base(message) { }
        }
        public class KeyIdentifierNotFoundException : System.Exception
        {
            public KeyIdentifierNotFoundException() : base() { }
            public KeyIdentifierNotFoundException(string message) : base(message) { }
        }
        public class KeyUniquenessException : System.Exception
        {
            public KeyUniquenessException() : base() { }
            public KeyUniquenessException(string message) : base(message) { }
        }
        public class KeyNotLoanableException : System.Exception
        {
            public KeyNotLoanableException() : base() { }
            public KeyNotLoanableException(string message) : base(message) { }
        }
        public class LoanIdNotFoundException : System.Exception
        {
            public LoanIdNotFoundException() : base() { }
            public LoanIdNotFoundException(string message) : base(message) { }
        }
        public class LoanUniquenessException : System.Exception
        {
            public LoanUniquenessException() : base() { }
            public LoanUniquenessException(string message) : base(message) { }
        }
        public class DependencyException : System.Exception
        {
            public DependencyException() : base() { }
            public DependencyException(string message) : base(message) { }
        }
    }
}
