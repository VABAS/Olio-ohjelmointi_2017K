using System;
using System.Collections.Generic;
using Gtk;

namespace KeyRegisterApp
{
    public class SettingsView : ScrolledWindow
    {
        private Dictionary<string, Entry> dictOfEntries;

        public SettingsView (SettingsHandler settingsHandler) : base()
        {
            dictOfEntries = new Dictionary<string, Entry> ();
            Table table = new Table (2, 0, false);

            Add (table);

            foreach (KeyValuePair<string, string> valuePair in settingsHandler.Settings) {
                // Creating temporary label and key objects.
                Label valueLabel = new Label (valuePair.Key + ":");
                Entry keyEntry = new Entry (valuePair.Value);

                // Adding them to dictionary, using setting as key and entry as value.
                dictOfEntries.Add (valuePair.Key, keyEntry);

                // Incrementing table rows
                table.NRows++;

                // Setting expand properties
                keyEntry.Expand = false;
                valueLabel.Expand = false;

                // Setting entry alignment
                valueLabel.SetAlignment (0, 0);

                // Attaching label and entry to table
                table.Attach (valueLabel, 0, 1, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
                table.Attach (keyEntry, 1, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
            }

            // Adding save button.
            table.NRows++;
            Button saveSettingsButton = new Button ("Save settings");
            saveSettingsButton.Clicked += saveSettingsButtonClicked;
            table.Attach (saveSettingsButton, 1, 2, table.NRows - 1, table.NRows, Gtk.AttachOptions.Fill, Gtk.AttachOptions.Fill, 3, 5);
        }

        private void saveSettingsButtonClicked (object o, EventArgs e)
        {
            // TODO: Real function must be implemented here...
            foreach (KeyValuePair<string, Entry> pair in dictOfEntries)
            {
                Console.WriteLine (pair.Key + " with value of " + pair.Value.Text);
            }
        }
    }
}

