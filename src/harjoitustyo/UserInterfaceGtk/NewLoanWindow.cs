using System;
using Gtk;

namespace KeyRegisterApp
{
    /// <summary>
    /// Window to add new loan.
    /// </summary>
    public class NewLoanWindow : SmallWindow
    {
        protected Entry keyIdEntry;
        protected Calendar dateStartCal;
        protected Calendar dateDueCal;
        protected CheckButton noDueDate;
        protected Entry loanerEntry;
        protected Entry additionalEntry;
        protected Button actionButton;
        protected Label keyIdLabel;
        protected Label buttonInstructionLabel;

        public NewLoanWindow (KeyRegister keyRegister, string title) : base (keyRegister, title)
        {
            // Setting deleteEvent.
            DeleteEvent += closeConfirmation;

            WidthRequest = 650;
            
            // Indentifier entry.
            keyIdLabel = new Label ("Key identifier (required):");
            keyIdEntry = new Entry ();
            keyIdEntry.WidthRequest = entryWidth;
            keyIdEntry.Changed += onEntryChange;
            container.Put (keyIdLabel, 10, 10 + groupSpacing * 0);
            container.Put (keyIdEntry, 10, 10 + groupSpacing * 0 + labelEntrySpacing);

            // Start date entry.
            Label dateStartLabel = new Label ("Loan starting date:");
            dateStartCal = new Calendar ();
            dateStartCal.WidthRequest = entryWidth;
            container.Put (dateStartLabel, 10, 10 + groupSpacing * 1);
            container.Put (dateStartCal, 10, 10 + groupSpacing * 1 + labelEntrySpacing);

            // Due date entry.
            Label dateDuetLabel = new Label ("Loan due date:");
            dateDueCal = new Calendar ();
            dateDueCal.WidthRequest = entryWidth;
            container.Put (dateDuetLabel, 320, 10 + groupSpacing * 1);
            container.Put (dateDueCal, 320, 10 + groupSpacing * 1 + labelEntrySpacing);

            // No due date checkbox
            noDueDate = new CheckButton ("No due date");
            //noDueDate.checked += onEntryChange;
            noDueDate.Clicked += onEntryChange;
            container.Put (noDueDate, 320, 10 + groupSpacing * 1 + 205);

            // Loaner entry.
            Label loanerLabel = new Label ("Loaner (optional):");
            loanerEntry = new Entry ();
            loanerEntry.WidthRequest = entryWidth;
            loanerEntry.Changed += onEntryChange;
            container.Put (loanerLabel, 10, 10 + groupSpacing * 4 + 20);
            container.Put (loanerEntry, 10, 10 + groupSpacing * 4 + 20 + labelEntrySpacing);

            // Loaner entry.
            Label additionalLabel = new Label ("Additional information (optional):");
            additionalEntry = new Entry ();
            additionalEntry.WidthRequest = entryWidth;
            additionalEntry.Changed += onEntryChange;
            container.Put (additionalLabel, 10, 10 + groupSpacing * 5 + 20);
            container.Put (additionalEntry, 10, 10 + groupSpacing * 5 + 20 + labelEntrySpacing);
            
            // Action button.
            actionButton = new Button ("Add loan");
            actionButton.Sensitive = false;
            actionButton.Clicked += onActionButtonClicked;
            container.Put (actionButton, 10, 10 + groupSpacing * 6 + 20);

            // Instruction label.
            buttonInstructionLabel = new Label ("Please fill all required fields");
            container.Put (buttonInstructionLabel, 105, 10 + groupSpacing * 6 + 20);

            ShowAll ();
        }

        private void onEntryChange (object o, EventArgs e)
        {
            somethingChanged = true;
            
            if (noDueDate.Active)
            {
                dateDueCal.Sensitive = false;
            }
            else
            {
                dateDueCal.Sensitive = true;
            }
            
            actionButton.Sensitive = keyIdEntry.TextLength >= Key.idMinLength;
            buttonInstructionLabel.Visible = !actionButton.Sensitive;
        }

        protected virtual void onActionButtonClicked (object o, EventArgs e)
        {
            string keyIdentifier = keyIdEntry.Text;
            string dateStart = dateStartCal.Year + "-" + (dateStartCal.Month + 1) + "-" + dateStartCal.Day;
            string dateDue = null;
            if (!noDueDate.Active)
            {
                dateDue = dateDueCal.Year + "-" + (dateDueCal.Month + 1) + "-" + dateDueCal.Day;
            }
            string loaner = loanerEntry.Text;
            string additional = additionalEntry.Text;

            try
            {
                int keyDbId = keyRegister.getKeyByIdentifier(keyIdentifier).DbId;
                Loan loan = new Loan (keyDbId, dateStart, dateDue, loaner, additional);
                keyRegister.addLoan(loan);
                Destroy();
            }
            catch (KeyRegister.LoanUniquenessException)
            {
                showWarning ("Couldn't add loan. Constraint failed.",
                             "There is already active loan for key " + keyIdentifier);
            }
            catch (KeyRegister.KeyIdentifierNotFoundException)
            {
                showWarning ("Couldn't add loan. Constraint failed.",
                             "Key with identifier " + keyIdentifier + " not found!");
            }
            catch (KeyRegister.KeyNotLoanableException)
            {
                showWarning ("Couldn't add loan. Key not loanable.");
            }
        }
    }
}

