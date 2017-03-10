using System;

namespace KeyRegisterApp
{
    public class NewLoanToKeyWindow : NewLoanWindow
    {
        public NewLoanToKeyWindow (KeyRegister keyRegister, int keyDbId)
            : base(keyRegister, "Add new loan for " + keyRegister.getKeyById(keyDbId).Identifier)
        {
            keyIdEntry.Text = keyRegister.getKeyById(keyDbId).Identifier;
            keyIdEntry.Sensitive = false;
            KeyIdLabel.Text = "Key identifier (locked)";
            somethingChanged = false;
        }
    }
}

