using System;

namespace KeyRegisterApp
{
    /// <summary>
    /// Class to handle key data.
    /// </summary>
    public class Key
    {
        private string identifier;
        private bool isMissing;
        private string name;
        private string description;
        private int dbId;
        
        public static readonly int idMinLength = 3;
        public static readonly int nameMinLength = 3;
        
        public int DbId {
            get { return dbId; }
        }

        public string Identifier {
            get { return identifier; }
        }
        public bool IsMissing {
            get { return isMissing; }
        }
        public string Name {
            get { return name; }
        }
        public string Description {
            get { return description; }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class. Takes all fields as parameter.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="isMissing">Set to <c>true</c> if key is missing.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <exception cref=""></exception>
        public Key (int dbId, string identifier, bool isMissing, string name, string description)
        {
            if (identifier.Length < idMinLength)
            {
                throw new IdTooShortException ("Identifier of key is shorter than set minimum of " +
                                               idMinLength.ToString ());
            }
            if (name.Length < nameMinLength)
            {
                throw new NameTooShortException ("Identifier of key is shorter than set minimum of " +
                                                 nameMinLength.ToString ());
            }
            this.dbId = dbId;
            this.identifier = identifier;
            this.isMissing = isMissing;
            this.name = name;
            this.description = description;
        }
        
        /// <summary>
        /// Initializes a new instance of the <see cref="Key"/> class. No dbId provided so it's initialized
        /// to -1.
        /// </summary>
        /// <param name="identifier">Identifier.</param>
        /// <param name="isMissing">Set to <c>true</c> if key is missing.</param>
        /// <param name="name">Name.</param>
        /// <param name="description">Description.</param>
        /// <exception cref=""></exception>
        public Key (string identifier, bool isMissing, string name, string description)
            : this(-1, identifier, isMissing, name, description)
        { }

        public override string ToString ()
        {
            return Identifier + ", " + IsMissing + ", " + Name + ", " + Description;
        }

        // Exception classes.
        public class IdTooShortException : System.Exception
        {
            public IdTooShortException() : base() { }
            public IdTooShortException(string message) : base(message) { }
        }
        public class NameTooShortException : System.Exception
        {
            public NameTooShortException() : base() { }
            public NameTooShortException(string message) : base(message) { }
        }
    }
}

