using System;
using Gtk;

namespace KeyRegisterApp
{
    /// <summary>
    /// Window to add new key.
    /// </summary>
    public class NewKeyWindow : SmallWindow
    {

        protected Entry idEntry;
        protected Entry nameEntry;
        protected Entry descriptionEntry;
        protected Button actionButton;
        protected Label idLabel;
        protected Label nameLabel;
        protected Label descriptionLabel;
        protected Label buttonInstructionLabel;
        protected CheckButton isMissingCB;


        public NewKeyWindow (KeyRegister keyRegister, string title) : base (keyRegister, title)
        {

            // Setting deleteEvent.
            DeleteEvent += closeConfirmation;

            // Indentifier entry.
            idLabel = new Label ("Identifier (required):");
            idEntry = new Entry ();
            idEntry.WidthRequest = entryWidth;
            idEntry.Changed += onEntryChange;
            container.Put (idLabel, 10, 10 + groupSpacing * 0);
            container.Put (idEntry, 10, 10 + groupSpacing * 0 + labelEntrySpacing);

            // Name entry.
            nameLabel = new Label ("Name (required):");
            nameEntry = new Entry ();
            nameEntry.WidthRequest = entryWidth;
            nameEntry.Changed += onEntryChange;
            container.Put (nameLabel, 10, 10 + groupSpacing * 1);
            container.Put (nameEntry, 10, 10 + groupSpacing * 1 + labelEntrySpacing);
            

            // Description entry.
            descriptionLabel = new Label ("Description:");
            descriptionEntry = new Entry ();
            descriptionEntry.WidthRequest = entryWidth;
            descriptionEntry.Changed += onEntryChange;
            container.Put (descriptionLabel, 10, 10 + groupSpacing * 2);
            container.Put (descriptionEntry, 10, 10 + groupSpacing * 2 + labelEntrySpacing);

            // Action button.
            actionButton = new Button ("Add key");
            actionButton.Sensitive = false;
            actionButton.Clicked += onActionButtonClicked;
            container.Put (actionButton, 10, 10 + groupSpacing * 3);

            // Instruction label.
            buttonInstructionLabel = new Label ("Please fill all required fields");
            container.Put (buttonInstructionLabel, 100, 10 + groupSpacing * 3);

            ShowAll ();
        }

        /// <summary>
        /// Called when some of the required entries is changed. Currently sets buttons sensitivity
        /// and instruction label visibility properties.
        /// </summary>
        protected void onEntryChange (object o, EventArgs e)
        {
            if (!somethingChanged)
            {
                somethingChanged = true;
            }
            actionButton.Sensitive = (idEntry.TextLength >= Key.idMinLength &&
                                      nameEntry.TextLength >= Key.nameMinLength);
            buttonInstructionLabel.Visible = !actionButton.Sensitive;
        }

        /// <summary>
        /// Called when actionButton-button is pressed. Handles the new key adding to 'database'.
        /// </summary>
        protected virtual void onActionButtonClicked (object o, EventArgs e)
        {
            try {
                keyRegister.addNewKey (idEntry.Text, false, nameEntry.Text, descriptionEntry.Text);
                Destroy ();
            }
            catch (KeyRegister.KeyUniquenessException)
            {
                showWarning ("Key not unigue! Please check the identifier field for confligt.",
                             "Name of the conflicting entry is '" +
                             keyRegister.getKeyByIdentifier (idEntry.Text).Name + "'");
            }
            catch (Key.IdTooShortException)
            {
                showWarning ("ERROR: Identifier of the key is shorter than set minimum of " +
                             Key.idMinLength.ToString () + "!");
            }
            catch (Key.NameTooShortException)
            {
                showWarning ("ERROR: Name of the key is sorter than set minimum of " +
                             Key.nameMinLength.ToString() + "!");
            }
        }
    }
}
