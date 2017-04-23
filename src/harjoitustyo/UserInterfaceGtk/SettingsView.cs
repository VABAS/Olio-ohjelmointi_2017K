using System;
using System.Collections.Generic;
using Gtk;

namespace KeyRegisterApp
{
    public class SettingsView : ScrolledWindow
    {
        private Dictionary<string, Entry> dictOfEntries;
        private Button saveSettingsButton;
        private Button revertSettingsButton;
        private Label informationLabel;
        private SettingsHandler settingsHandler;

        public EventHandler addSaveButtonEvent {
            set {
                saveSettingsButton.Clicked += value;
            }
        }
        public EventHandler addRevertButtonEvent {
            set {
                revertSettingsButton.Clicked += value;
            }
        }

        public Dictionary<string, Entry> DictOfEntries {
            get { return dictOfEntries; }
        }

        public SettingsView (SettingsHandler settingsHandler) : base()
        {
            this.settingsHandler = settingsHandler;

            dictOfEntries = new Dictionary<string, Entry> ();

            // Table with two columns and initially zero rows.
            Table table = new Table (2, 0, false);

            Add (table);

            // Going through each setting value and adding it here.
            foreach (KeyValuePair<string, string> valuePair in settingsHandler.Settings) {
                // Creating temporary label and key objects.
                Label keyLabel = new Label (valuePair.Key + ":");
                Entry valueEntry = new Entry (valuePair.Value);

                // Adding them to dictionary, using setting as key and entry as value.
                dictOfEntries.Add (valuePair.Key, valueEntry);

                // Incrementing table rows so that new items can fit.
                table.NRows++;

                // Setting expand properties.
                valueEntry.Expand = false;
                keyLabel.Expand = false;

                // Setting entry alignment.
                keyLabel.SetAlignment (0, 0);

                // Attaching label and entry to table.
                table.Attach (keyLabel, 0, 1, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
                table.Attach (valueEntry, 1, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);

                valueEntry.Changed += somethingChanged;
            }

            // Adding save button.
            table.NRows++;
            saveSettingsButton = new Button ("Save settings");
            revertSettingsButton = new Button ("Revert settings");

            Table buttonsTable = new Table (2, 1, false);
            buttonsTable.RowSpacing = 3;

            table.Attach (buttonsTable, 0, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
            
            buttonsTable.Attach (saveSettingsButton, 0, 1, 0, 1);
            buttonsTable.Attach (revertSettingsButton, 1, 2, 0, 1);

            // Adding information label.
            table.NRows++;
            informationLabel = new Label ("Settings changed! You should save the settings before continuing to use the program.");
            informationLabel.LineWrap = true;
            informationLabel.SetAlignment (0, 0);
            table.Attach (informationLabel, 0, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
            this.Shown += shownHandler;
            this.addSaveButtonEvent = hideInformationLabelHandler;
            this.addRevertButtonEvent = doRevert;
        }

        void shownHandler (object o, EventArgs e)
        {
            hideInformationLabel ();
        }

        private void somethingChanged (object o, EventArgs e)
        {
            informationLabel.Visible = true;
        }

        private void doRevert (object o, EventArgs e)
        {
            foreach (KeyValuePair<string, Entry> valuePair in dictOfEntries) {
                valuePair.Value.Text = settingsHandler.Settings [valuePair.Key];
            }
            hideInformationLabel ();
        }

        public void hideInformationLabel ()
        {
            informationLabel.Visible = false;
        }

        public void hideInformationLabelHandler (object o, EventArgs e)
        {
            hideInformationLabel ();
        }

    }
}

