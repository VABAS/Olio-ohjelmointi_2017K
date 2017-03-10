using System;
using Gtk;

namespace KeyRegisterApp
{
    public class KeyViewMenu : VButtonBox
    {
        public Button addNewKey;
        public Button editKey;
        public Button removeKey;
        public Button addLoan;
        public Button showDetails;
        public Button toggleMissing;

        public KeyViewMenu () : base()
        {
            this.Spacing = 3;
            Layout = ButtonBoxStyle.Center;
            addNewKey = new Button ("Add new key");
            editKey = new Button ("Edit selected");
            removeKey = new Button ("Remove selected");
            addLoan = new Button ("Loan selected");
            showDetails = new Button ("Show details");
            toggleMissing = new Button ("Toggle missing");
            Add (addNewKey);
            Add (editKey);
            Add (removeKey);
            Add (addLoan);
            Add (showDetails);
            Add (toggleMissing);

            ShowAll ();
        }
    }
}

