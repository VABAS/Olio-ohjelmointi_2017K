using System;

namespace KeyRegisterApp
{
    public class EditKeyWindow : NewKeyWindow
    {
        private Key key;
        public EditKeyWindow (KeyRegister keyRegister, string title, Key key) : base (keyRegister, title)
        {
            this.key = key;
            idEntry.Text = key.Identifier;
            nameEntry.Text = key.Name;
            descriptionEntry.Text = key.Description;
            somethingChanged = false;
            actionButton.Label = "Modify key";
            actionButton.Sensitive = false;
            buttonInstructionLabel.Text = "Nothing modified";
            buttonInstructionLabel.Visible = true;
            container.Move (buttonInstructionLabel, 120, 10 + groupSpacing * 3);
        }

        protected override void onActionButtonClicked (object o, EventArgs e)
        {
            string newIdentifier = null;
            string newName = null;
            string newDescription = null;
            
            if (key.Identifier != idEntry.Text)
            {
                newIdentifier = idEntry.Text;
            }
            if (key.Name != nameEntry.Text)
            {
                newName = nameEntry.Text;
            }
            if (key.Description != descriptionEntry.Text)
            {
                newDescription = descriptionEntry.Text;
            }

            keyRegister.modifyKeyById (key.DbId,
                                       newIdentifier,
                                       newName,
                                       newDescription);
            Destroy ();
        }
    }
}

