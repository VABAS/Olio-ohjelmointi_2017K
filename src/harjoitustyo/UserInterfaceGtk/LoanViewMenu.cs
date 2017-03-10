using System;
using Gtk;

namespace KeyRegisterApp
{
    public class LoanViewMenu : VButtonBox
    {
        public Button addNewLoan;
        public Button editSelectedLoan;
        public Button returnSelectedLoan;

        public LoanViewMenu () : base()
        {
            this.Spacing = 3;
            Layout = ButtonBoxStyle.Center;
            addNewLoan = new Button ("Add new loan");
            editSelectedLoan = new Button ("Edit selected");
            returnSelectedLoan = new Button ("Return selected");

            Add (addNewLoan);
            Add (editSelectedLoan);
            Add (returnSelectedLoan);

            ShowAll ();
        }
    }
}

