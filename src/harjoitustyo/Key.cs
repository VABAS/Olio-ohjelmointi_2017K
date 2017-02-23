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
		public Key (string identifier, bool isMissing, string name, string description)
		{
			this.identifier = identifier;
			this.isMissing = isMissing;
			this.name = name;
			this.description = description;
		}

		public override string ToString ()
		{
			return Identifier + ", " + IsMissing + ", " + Name + ", " + Description;
		}
	}
}

