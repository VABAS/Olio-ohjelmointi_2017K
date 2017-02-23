using System;

namespace KeyRegisterApp
{
	/// <summary>
	/// Class to handle loan data.
	/// </summary>
	public class Loan
	{
		private int keyId;
		private string dateStart;
		private string dateEnd;
		private string loanedTo;
		private bool returned;
		private string additionalInformation;
		
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
		/// <param name="keyId">Id of the key</param>
		/// <param name="dateStart">Starting date of the loan</param>
		/// <param name="dateEnd">Ending date of the loan</param>
		/// <param name="loanedTo">To whom is referenced key loaned</param>
		/// <param name="returned">If set to <c>true</c> loan is returned.</param>
		/// <param name="addInfo">Additional information about the loan.</param>
		public Loan (int keyId, string dateStart, string dateEnd, string loanedTo, bool returned, string addInfo)
		{
			this.keyId = keyId;
			this.dateStart = dateStart;
			this.dateEnd = dateEnd;
			this.loanedTo = loanedTo;
			this.returned = returned;
			this.additionalInformation = addInfo;
		}

		/// <summary>
		/// Sets loan returned. Cannot be undone.
		/// </summary>
		public void setReturned ()
		{
			returned = true;
		}
	}
}

