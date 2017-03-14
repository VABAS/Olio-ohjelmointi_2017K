using System;

namespace KeyRegisterApp
{
    public class EditLoanWindow : NewLoanWindow
    {
        private int loanDbId;
        public EditLoanWindow (KeyRegister keyRegister, int loanDbId)
            : base(keyRegister, "Edit loan " + loanDbId)
        {
            Loan loan = keyRegister.getLoanById (loanDbId);
            this.loanDbId = loanDbId;
            keyIdEntry.Text = keyRegister.getKeyById(loan.KeyId).Identifier;
            keyIdEntry.Sensitive = false;
            keyIdEntry.TooltipText = "Key identifier cannot be changed. " +
                                     "Issue new loan for new key if you want to transfer loan";
            keyIdLabel.Text = "Key identifier (locked)";

            // Setting calendars.
            dateStartCal.Year = loan.parseStartDate () [0];
            dateStartCal.Month = loan.parseStartDate () [1] - 1;
            dateStartCal.Day = loan.parseStartDate () [2];

            if (loan.DateEnd != null) {
                noDueDate.Active = false;
                dateDueCal.Year = loan.parseDueDate () [0];
                dateDueCal.Month = loan.parseDueDate () [1] - 1;
                dateDueCal.Day = loan.parseDueDate () [2];
            }
            else {
                dateDueCal.Date = dateStartCal.Date;
                noDueDate.Active = true;
            }

            // Setting button text.
            actionButton.Label = "Edit loan";

            // Setting loaner
            loanerEntry.Text = loan.LoanedTo;

            // Setting addInfo
            additionalEntry.Text = loan.AdditionalInformation;
            
            somethingChanged = false;
        }

        protected override void onActionButtonClicked (Object o, EventArgs e)
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

            keyRegister.modifyLoanById (loanDbId,
                                        dateStart,
                                        dateDue,
                                        loaner,
                                        additional);
            Destroy();
        }
    }
}

