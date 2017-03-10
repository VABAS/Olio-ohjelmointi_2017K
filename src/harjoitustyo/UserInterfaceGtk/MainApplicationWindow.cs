using System;
using Gtk;

namespace KeyRegisterApp
{
    public partial class MainApplicationWindow : Window
    {
        private KeyView keyView;
        private LoanView loanView;
        private KeyRegister keyRegister;
        private MainTabbedView noteBook;
        //private Fixed container;
        private HBox container;

        private KeyViewMenu keyViewMenu;
        private LoanViewMenu loanViewMenu;

        // Main constructor.
        public MainApplicationWindow () : base ("Key register application")
        {
            keyRegister = new KeyRegisterXml ("KeyRegister.xml");

            // Setting size of the window.
            SetSizeRequest (900, 700);

            // Do not allow resizing of this window.
            Resizable = false;

            // Adding deleteEvent.
            DeleteEvent += OnDeleteEvent;

            //container = new Fixed ();
            container = new HBox ();


            Add (container);

            // Adding menus.
            keyViewMenu = new KeyViewMenu ();
            keyViewMenu.addNewKey.Clicked += addNewKeyClicked;
            keyViewMenu.editKey.Clicked += editKeyClicked;
            keyViewMenu.removeKey.Clicked += removeKeyClicked;
            keyViewMenu.addLoan.Clicked += addLoanToKeyClicked;
            keyViewMenu.showDetails.Clicked += showKeyDetailsClicked;
            keyViewMenu.toggleMissing.Clicked += toggleMissingClicked;
            //container.Put (keyViewMenu, 0, 0);
            container.PackStart (keyViewMenu, true, true, 5);
            keyViewMenu.Halign = Align.Start;
            keyViewMenu.Valign = Align.Start;
            keyViewMenu.MarginTop = 50;
            //keyViewMenu.SizeAllocated += menuPlacement;

            loanViewMenu = new LoanViewMenu ();
            loanViewMenu.addNewLoan.Clicked += addNewLoanClicked;
            loanViewMenu.editSelectedLoan.Clicked += editSelectedLoanClicked;
            loanViewMenu.returnSelectedLoan.Clicked += returnSelectedLoanClicked;
            //container.Put (loanViewMenu, 0, 0);
            loanViewMenu.Halign = Align.Start;
            loanViewMenu.Valign = Align.Start;
            loanViewMenu.MarginTop = 50;
            container.PackStart (loanViewMenu, true, true, 5);
            //loanViewMenu.SizeAllocated += menuPlacement;

            // Adding tabbed view.
            noteBook = new MainTabbedView ();

            //container.Put (noteBook, 300, 0);
            container.PackStart (noteBook, true, true, 5);

            keyView = new KeyView (keyRegister);
            noteBook.Add (keyView);
            noteBook.SetTabLabelText (keyView, "Key listing");

            loanView = new LoanView (keyRegister);
            noteBook.Add (loanView);
            noteBook.SetTabLabelText (loanView, "Loan listing");

            // Updating tables.
            doUpdates ();

            // Showing all elements.
            ShowAll ();

            hideAllMenus ();
            keyViewMenu.Show ();

            noteBook.SwitchPage += setMenuPage;
        }

        /*private void menuPlacement (object o, EventArgs e)
        {
            Widget w = (Widget)o;
            //container.Move (w, 300 - 10 - w.AllocatedWidth, 65);
        }*/

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
            default:
                throw new NotImplementedException ("No menu for page #" + noteBook.CurrentPage);
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

        /// <summary>
        /// Method run when main-window is closed.
        /// </summary>
        protected void OnDeleteEvent (object sender, DeleteEventArgs a)
        {
            Application.Quit ();
        }

        /// <summary>
        /// Method run when new key window is closed.
        /// </summary>
        protected void newKeyWindowDestroyed (object o, EventArgs a)
        {
            doUpdates ();
        }

        /// <summary>
        /// Method run when edit key window is closed.
        /// </summary>
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
            //Key key = keyRegister.getKeyByIdentifier (keyView.SelectedKeyIdentifier);
            Key key = keyRegister.getKeyById (keyView.SelectedDbId);
            Window editKeyWindow = new EditKeyWindow (keyRegister, "Edit key", key);
            editKeyWindow.Destroyed += editKeyWindowDestroyed;
        }

        /// <summary>
        /// Called when remove key button is pressed. Handles key removal.
        /// </summary>
        protected void removeKeyClicked (object o, EventArgs e)
        {
            //int dbId = keyRegister.getKeyIdByIdentifier (keyView.SelectedKeyIdentifier);
            int dbId = keyView.SelectedDbId;
            Key key = keyRegister.getKeyById (dbId);
            bool doRemove = showConfirmationDialog ("Do you really want to delete key with identifier '" +
                                                    key.Identifier + "'?");
            if (doRemove)
            {
                keyRegister.deleteKeyById (dbId);
                doUpdates ();
            }
        }

        protected void showKeyDetailsClicked (object o, EventArgs e)
        {
            Window keyDetailsWindow = new KeyDetailsWindow (keyRegister, keyView.SelectedDbId);
            keyDetailsWindow.Destroyed += showKeyDetailsWindowDestroyed;
        }

        /// <summary>
        ///  Called when toggle missing status button is pressed. Changes key missing status.
        /// </summary>
        protected void toggleMissingClicked (object o, EventArgs e)
        {
            int keyId = keyView.SelectedDbId;
            if (keyRegister.getKeyById(keyId).IsMissing)
            {
                keyRegister.setKeyToNotMissingById (keyId);
            }
            else
            {
                keyRegister.setKeyToMissingById (keyId);
            }
            doUpdates ();
        }

        protected void addLoanToKeyClicked (object o, EventArgs e)
        {
            Window newLoanToKeyWindow = new NewLoanToKeyWindow (keyRegister, keyView.SelectedDbId);
            newLoanToKeyWindow.Destroyed += newLoanWindowDestroyed;
        }

        protected void addNewLoanClicked (object o, EventArgs e)
        {
            Window newLoanWindow = new NewLoanWindow (keyRegister, "Add new loan");
            newLoanWindow.Destroyed += newLoanWindowDestroyed;
        }

        protected void editSelectedLoanClicked (object o, EventArgs e)
        {
            Window editLoanWindow = new EditLoanWindow (keyRegister, loanView.SelectedDbId);
            editLoanWindow.Destroyed += editLoanWindowDestroyed;
        }

        protected void returnSelectedLoanClicked (object o, EventArgs e)
        {
            keyRegister.setLoanReturned (loanView.SelectedDbId);
            doUpdates ();
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
    }
}

