using System;
using System.Collections.Generic;
using Gtk;

namespace KeyRegisterApp
{
    public class SettingsView : ScrolledWindow
    {
        private Dictionary<string, Entry> dictOfEntries;
        private Button saveSettingsButton;
        private Label informationLabel;
        public EventHandler addButtonEvent {
            set {
                saveSettingsButton.Clicked += value;
            }
        }

        public Dictionary<string, Entry> DictOfEntries {
            get { return dictOfEntries; }
        }

        public SettingsView (SettingsHandler settingsHandler) : base()
        {
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
            table.Attach (saveSettingsButton, 1, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);

            // Adding information label.
            table.NRows++;
            informationLabel = new Label ("Settings changed! You should save or revert the settings before continuing to use the program.");
            informationLabel.LineWrap = true;
            informationLabel.SetAlignment (0, 0);
            table.Attach (informationLabel, 0, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
            this.Shown += shownHandler;
        }

        void shownHandler (object o, EventArgs e)
        {
            hideInformationLabel ();
        }

        private void somethingChanged (object o, EventArgs e)
        {
            // TODO: Changing of view should not be allowed when settings are changed? Or should they?
            informationLabel.Visible = true;
        }

        public void hideInformationLabel ()
        {
            informationLabel.Visible = false;
        }
    }
}

