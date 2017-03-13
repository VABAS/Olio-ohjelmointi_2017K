using System;

namespace KeyRegisterApp
{
    /// <summary>
    /// Class to handle loan data.
    /// </summary>
    public class Loan
    {
        private int loanDbId;
        private int keyId;
        private string dateStart;
        private string dateEnd;
        private string loanedTo;
        private bool returned;
        private string additionalInformation;

        public int LoanDbId {
            get { return loanDbId; }
            set { value = loanDbId; }
        }

        public int KeyId {
            get { return keyId; }
        }
        public string DateStart {
            get {return dateStart; }
        }
        public string DateEnd {
            get { return dateEnd; }
        }
        public string LoanedTo {
            get { return loanedTo; }
        }
        public bool Returned {
            get { return returned; }
        }
        public string AdditionalInformation {
            get { return additionalInformation; }
        }

        /// <summary>
        /// Creates new instance of <see cref="Loan"/> class. dateEnd can be set to <see cref="null"/>.
        /// </summary>
        /// <param name="loanDbId">Database id of the loan in question.</param>
        /// <param name="keyId">Id of the key</param>
        /// <param name="dateStart">Starting date of the loan</param>
        /// <param name="dateEnd">Ending date of the loan</param>
        /// <param name="loanedTo">To whom is referenced key loaned</param>
        /// <param name="returned">If set to <c>true</c> loan is returned.</param>
        /// <param name="addInfo">Additional information about the loan.</param>
        public Loan (int loanDbId, int keyId, string dateStart, string dateEnd, string loanedTo, bool returned, string addInfo)
        {
            // Checking that dates are properly formatted.
            DateTime temporaryDate;
            if (dateStart.Split ('-').Length != 3 ||
                !DateTime.TryParse (dateStart, out temporaryDate)) {
                throw new InvalidDateException ("Invalid start date.");
            }
            if (dateEnd != null) {
                if (dateEnd.Split ('-').Length != 3 ||
                    !DateTime.TryParse (dateEnd, out temporaryDate)) {
                    throw new InvalidDateException ("Invalid due date.");
                }
            }

            this.loanDbId = loanDbId;
            this.keyId = keyId;
            this.dateStart = dateStart;
            this.dateEnd = dateEnd;
            this.loanedTo = loanedTo;
            this.returned = returned;
            this.additionalInformation = addInfo;
        }
        

        /// <summary>
        /// Creates new instance of <see cref="Loan"/> class. dateEnd can be set to <see cref="null"/>.
        /// No loanDbId defined.
        /// </summary>
        /// <param name="keyId">Id of the key</param>
        /// <param name="dateStart">Starting date of the loan</param>
        /// <param name="dateEnd">Ending date of the loan</param>
        /// <param name="loanedTo">To whom is referenced key loaned</param>
        /// <param name="returned">If set to <c>true</c> loan is returned.</param>
        /// <param name="addInfo">Additional information about the loan.</param>
        public Loan (int keyId, string dateStart, string dateEnd, string loanedTo, bool returned, string addInfo)
            : this (-1, keyId, dateStart, dateEnd, loanedTo, returned, addInfo)
        { }
        
        /// <summary>
        /// Creates new instance of <see cref="Loan"/> class. dateEnd can be set to <see cref="null"/>. No 'returned' information.
        /// </summary>
        /// <param name="keyId">Id of the key</param>
        /// <param name="dateStart">Starting date of the loan</param>
        /// <param name="dateEnd">Ending date of the loan</param>
        /// <param name="loanedTo">To whom is referenced key loaned</param>
        /// <param name="addInfo">Additional information about the loan</param>
        public Loan (int keyId, string dateStart, string dateEnd, string loanedTo, string addInfo)
            : this (keyId, dateStart, dateEnd, loanedTo, false, addInfo)
        { }

        private int[] parseDate (string date)
        {
            int[] dateArray = new int[3];
            string[] dateString = date.Split ('-');
            for (int i = 0; i < 3; i++) {
                dateArray [i] = int.Parse (dateString [i]);
            }
            return dateArray;
        }

        public int[] parseStartDate ()
        {
            return parseDate (dateStart);
        }

        public int[] parseDueDate ()
        {
            if (dateEnd != null) {
                return parseDate (dateEnd);
            } else {
                return null;
            }
        }

        /// <summary>
        /// Sets loan returned. Cannot be undone.
        /// </summary>
        public void setReturned ()
        {
            returned = true;
        }

        public class InvalidDateException : System.Exception
        {
            public InvalidDateException() : base() { }
            public InvalidDateException(string message) : base(message) { }
        }
    }
}

