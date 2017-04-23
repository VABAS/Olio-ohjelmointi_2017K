using System;
using Gtk;

namespace KeyRegisterApp
{
    public partial class MainApplicationWindow : Window
    {
        private KeyView keyView;
        private LoanView loanView;
        private SettingsView settingsView;
        private MainTabbedView noteBook;
        private HBox container;

        private KeyViewMenu keyViewMenu;
        private LoanViewMenu loanViewMenu;
        
        private KeyRegister keyRegister;
        private SettingsHandler settingsHandler;

        // Main constructor.
        public MainApplicationWindow () : base ("Key register application")
        {
            loadSettings ();

            // Setting size of the window.
            SetSizeRequest (900, 700);

            // Do not allow resizing of this window.
            Resizable = false;

            // Adding deleteEvent.
            DeleteEvent += OnDeleteEvent;

            // Creating new HBox for container widget to our window.
            container = new HBox ();

            // Adding container to the window.
            Add (container);

            // Adding menus. Button clicks assigned here also.
            keyViewMenu = new KeyViewMenu ();
            keyViewMenu.addNewKey.Clicked += addNewKeyClicked;
            keyViewMenu.editKey.Clicked += editKeyClicked;
            keyViewMenu.removeKey.Clicked += removeKeyClicked;
            keyViewMenu.addLoan.Clicked += addLoanToKeyClicked;
            keyViewMenu.showDetails.Clicked += showKeyDetailsClicked;
            keyViewMenu.toggleMissing.Clicked += toggleMissingClicked;
            container.PackStart (keyViewMenu, true, true, 5);
            keyViewMenu.Halign = Align.Start;
            keyViewMenu.Valign = Align.Start;
            keyViewMenu.MarginTop = 50;

            loanViewMenu = new LoanViewMenu ();
            loanViewMenu.addNewLoan.Clicked += addNewLoanClicked;
            loanViewMenu.editSelectedLoan.Clicked += editSelectedLoanClicked;
            loanViewMenu.returnSelectedLoan.Clicked += returnSelectedLoanClicked;
            loanViewMenu.Halign = Align.Start;
            loanViewMenu.Valign = Align.Start;
            loanViewMenu.MarginTop = 50;
            container.PackStart (loanViewMenu, true, true, 5);

            // Adding tabbed view.
            noteBook = new MainTabbedView ();

            container.PackStart (noteBook, true, true, 5);

            // Adding keyView tab.
            keyView = new KeyView (keyRegister);
            noteBook.Add (keyView);
            noteBook.SetTabLabelText (keyView, "Key listing");

            // Adding loanView tab.
            loanView = new LoanView (keyRegister);
            noteBook.Add (loanView);
            noteBook.SetTabLabelText (loanView, "Loan listing");

            // Adding settings tab.
            settingsView = new SettingsView (settingsHandler);
            noteBook.Add (settingsView);
            noteBook.SetTabLabelText (settingsView, "Settings");
            settingsView.addSaveButtonEvent = saveSettingsButtonClicked;

            // Updating tables.
            doUpdates ();

            // Showing all elements.
            ShowAll ();

            hideAllMenus ();
            keyViewMenu.Show ();

            noteBook.SwitchPage += setMenuPage;
        }

        private void hideAllMenus()
        {
            keyViewMenu.Hide ();
            loanViewMenu.Hide ();
        }

        /// <summary>
        /// Sets the menu page depending on the page of tabbed view 'notebook'.
        /// </summary>
        private void setMenuPage (object o, EventArgs e)
        {
            hideAllMenus ();
            switch (noteBook.CurrentPage)
            {
            case 0:
                keyViewMenu.Show ();
                break;
            case 1:
                loanViewMenu.Show ();
                break;
            case 2:
                // Settings page has no menu.
                break;
            default:
                throw new NotImplementedException ("No menu for page #" + noteBook.CurrentPage);
            }
        }

        ////////////////////
        //  FOR KEY-VIEW  //
        ////////////////////
        /// <summary>
        /// Opening new key window.
        /// </summary>
        protected void addNewKeyClicked (object o, EventArgs e)
        {
            Window newKeyWindow = new NewKeyWindow (keyRegister, "Add new key");
            newKeyWindow.Destroyed += newKeyWindowDestroyed;
        }

        /// <summary>
        /// Opening edit key window.
        /// </summary>
        protected void editKeyClicked (object o, EventArgs e)
        {
            Key key;

            // If getKeyById throws KeyIdNotFoundException nothing is selected.
            try
            {
                key = keyRegister.getKeyById (keyView.SelectedDbId);
            }
            catch (KeyRegister.KeyIdNotFoundException)
            {
                return;
            }
            Window editKeyWindow = new EditKeyWindow (keyRegister, "Edit key", key);
            editKeyWindow.Destroyed += editKeyWindowDestroyed;
        }

        /// <summary>
        /// Called when remove key button is pressed. Handles key removal.
        /// </summary>
        protected void removeKeyClicked (object o, EventArgs e)
        {
            int dbId = keyView.SelectedDbId;
            Key key;

            // If getKeyById throws KeyIdNotFoundException nothing is selected.
            try
            {
                key = keyRegister.getKeyById (dbId);
            }
            catch (KeyRegister.KeyIdNotFoundException)
            {
                return;
            }
            bool doRemove = showConfirmationDialog ("Do you really want to delete key with identifier '" +
                                                    key.Identifier + "'?");
            if (doRemove)
            {
                try {
                    keyRegister.deleteKeyById (dbId);
                }
                catch (KeyRegister.DependencyException ex) {
                    showInfoDialog (ex.Message);
                }
                doUpdates ();
            }
        }

        protected void showKeyDetailsClicked (object o, EventArgs e)
        {
            Window keyDetailsWindow;
            try
            {
                keyDetailsWindow = new KeyDetailsWindow (keyRegister, keyView.SelectedDbId);
            }
            catch (KeyRegister.KeyIdNotFoundException)
            {
                return;
            }
            keyDetailsWindow.Destroyed += showKeyDetailsWindowDestroyed;
        }

        /// <summary>
        ///  Called when toggle missing status button is pressed. Changes key missing status.
        /// </summary>
        protected void toggleMissingClicked (object o, EventArgs e)
        {
            int keyId = keyView.SelectedDbId;
            try
            {
                if (keyRegister.getKeyById(keyId).IsMissing)
                {
                    keyRegister.setKeyToNotMissingById (keyId);
                }
                else
                {
                    keyRegister.setKeyToMissingById (keyId);
                }
            }
            catch (KeyRegister.KeyIdNotFoundException)
            {
                return;
            }
            doUpdates ();
        }

        protected void addLoanToKeyClicked (object o, EventArgs e)
        {
            Window newLoanToKeyWindow;
            try
            {
                newLoanToKeyWindow = new NewLoanToKeyWindow (keyRegister, keyView.SelectedDbId);
            }
            catch (KeyRegister.KeyIdNotFoundException)
            {
                return;
            }
            newLoanToKeyWindow.Destroyed += newLoanWindowDestroyed;
        }
        /////////////////////
        //  FOR LOAN-VIEW  //
        /////////////////////
        protected void addNewLoanClicked (object o, EventArgs e)
        {
            Window newLoanWindow = new NewLoanWindow (keyRegister, "Add new loan");
            newLoanWindow.Destroyed += newLoanWindowDestroyed;
        }

        protected void editSelectedLoanClicked (object o, EventArgs e)
        {
            Window editLoanWindow;
            try
            {
                editLoanWindow = new EditLoanWindow (keyRegister, loanView.SelectedDbId);
            }
            catch (KeyRegister.LoanIdNotFoundException)
            {
                return;
            }
            editLoanWindow.Destroyed += editLoanWindowDestroyed;
        }

        protected void returnSelectedLoanClicked (object o, EventArgs e)
        {
            try
            {
            keyRegister.setLoanReturned (loanView.SelectedDbId);
            }
            catch (KeyRegister.LoanIdNotFoundException)
            {
                return;
            }
            doUpdates ();
        }

        /////////////////////////
        //  FOR SETTINGS-VIEW  //
        /////////////////////////
        private void saveSettingsButtonClicked (object o, EventArgs e)
        {
            bool somethingChanged = false;
            foreach (System.Collections.Generic.KeyValuePair<string, Entry> pair in settingsView.DictOfEntries) {
                if (settingsHandler.Settings [pair.Key] != pair.Value.Text) {
                    settingsHandler.Settings [pair.Key] = pair.Value.Text;
                    somethingChanged = true;
                }
            }
            if (somethingChanged) {
                settingsHandler.writeToFile ();
                loadSettings ();
                doUpdates ();
            }
            else {
                showInfoDialog ("Nothing changed");
            }
        }

        /////////////////////////////
        //  WINDOW DESTROY EVENTS  //
        /////////////////////////////
        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
        }

        protected void newKeyWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        protected void editKeyWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        protected void newLoanWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        protected void editLoanWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        protected void showKeyDetailsWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        /////////////////////
        //  OTHER METHODS  //
        /////////////////////

        public void loadSettings ()
        {
            // Getting settings.
            this.settingsHandler = new SettingsHandler ();

            // Setting KeyRegister object to represent some of the implemented data sources. New
            // sources can be easily added by first inheriting from KeyRegister-class and
            // implementing the required methods. Then adding it here, will make it available.
            //KeyRegister kr;
            if (settingsHandler.Settings["RegisterType"].ToUpper() == "XML")
            {
                this.keyRegister = new KeyRegisterXml(settingsHandler.Settings["RegisterXmlFileLocation"]);
            }
            else
            {
                throw new SettingsHandler.InvalidSettingValue ("Invalid register type '" +
                                                               settingsHandler.Settings["RegisterType"] +
                                                               "' specified");
            }
        }

        /// <summary>
        /// Updates key and loan tables from register.
        /// </summary>
        public void doUpdates ()
        {
            keyView.addValues (keyRegister.getAllKeys ());
            loanView.addValues (keyRegister.getAllActiveLoans ());
        }

        private bool showConfirmationDialog (string text)
        {
            MessageDialog confirmation = new MessageDialog (this,
                                                            DialogFlags.DestroyWithParent,
                                                            MessageType.Warning,
                                                            ButtonsType.YesNo,
                                                            text);
            int retVal = confirmation.Run ();
            confirmation.Destroy ();
            if (retVal == -8)
            {
                return true;
            }
            else if (retVal == -9)
            {
                return false;
            }
            else
            {
                throw new NotImplementedException ("Unknown button press value for confirmation dialog.");
            }
        }

        private void showInfoDialog (string text)
        {
            MessageDialog confirmation = new MessageDialog (this,
                                                            DialogFlags.DestroyWithParent,
                                                            MessageType.Info,
                                                            ButtonsType.Close,
                                                            text);
            confirmation.Run ();
            confirmation.Destroy ();
        }
    }
}

