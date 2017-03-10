using System;
using Gtk;

namespace KeyRegisterApp
{
    public class KeyDetailsWindow : NewKeyWindow
    {
        protected Key key;

        public KeyDetailsWindow (KeyRegister keyRegister, int keyDbId)
            : base(keyRegister, "Details of key " + keyRegister.getKeyById(keyDbId).Identifier)
        {
            key = keyRegister.getKeyByIdentifier (keyRegister.getKeyById(keyDbId).Identifier);
            idEntry.Text = key.Identifier;
            idEntry.Sensitive = false;
            nameEntry.Text = key.Name;
            nameEntry.Sensitive = false;
            descriptionEntry.Text = key.Description;
            descriptionEntry.Sensitive = false;

            idLabel.Text = "Identifier:";
            nameLabel.Text = "Name:";

            // Destroying button and its label becouse they are not needed here.
            actionButton.Destroy ();
            buttonInstructionLabel.Destroy ();

            // Displaying missing information.
            Label missingInfoLabel = new Label (null);
            if (key.IsMissing)
            {
                missingInfoLabel.Markup = "Key is marked as missing. It cannot be loaned.";
            }
            else
            {
                missingInfoLabel.Markup = "Key is not marked as missing.";
            }
            container.Put (missingInfoLabel, 10, 10 + groupSpacing * 3);

            // Displaying loan information.
            Label loanInfoLabel = new Label (null);
            loanInfoLabel.Markup = "<b>Loan information:</b>";
            container.Put (loanInfoLabel, 10, 10 + groupSpacing * 4 - 40);
            Label loanInfoDescLabel = new Label ();

            Loan loan = keyRegister.getActiveLoanByKeyId (key.DbId);

            // If loan object references to null, there is no loan for this key.
            if (loan != null)
            {
                if (loan.LoanedTo.Length > 0)
                {
                    loanInfoDescLabel.Text = "Currently loaned to '" + loan.LoanedTo + "'.";
                }
                else
                {
                    loanInfoDescLabel.Text = "Key is currently loaned. No loaner specified.";
                }
                loanInfoDescLabel.Text += "\n";
                if (loan.DateEnd.Length > 0)
                {
                    loanInfoDescLabel.Text += "Loan due at " + loan.DateEnd + ".";
                }
                else
                {
                    loanInfoDescLabel.Text += "No due date specified.";
                }
            }
            else
            {
                loanInfoDescLabel.Text = "Key is not currently loaned.";
            }
            container.Put (loanInfoDescLabel, 10, 10 + groupSpacing * 4 - 20);

            somethingChanged = false;

            ShowAll ();
        }
    }
}

