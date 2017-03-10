using System;
using Gtk;

namespace KeyRegisterApp
{
    public abstract class SmallWindow : Window
    {
        protected static readonly int entryWidth = 300;
        protected static readonly int labelEntrySpacing = 20;
        protected static readonly int groupSpacing = 70;

        protected Fixed container;
        
        protected KeyRegister keyRegister;

        protected bool somethingChanged = false;

        public SmallWindow (KeyRegister kr, string title) : base(title)
        {
            keyRegister = kr;
            // Setting size of the window.
            SetSizeRequest (400, 500);

            // Do not allow resizing of this window.
            Resizable = false;

            container = new Fixed ();

            Add (container);
        }

        /// <summary>
        /// Asks for confirmation before quitting if some of the entries has been changed.
        /// </summary>
        protected void closeConfirmation (object o, DeleteEventArgs e)
        {
            if (!somethingChanged)
            {
                return;
            }
            MessageDialog confirmation = new MessageDialog (this,
                                                            DialogFlags.DestroyWithParent,
                                                            MessageType.Question,
                                                            ButtonsType.YesNo,
                                                            "You have changed some of the fields. Do you really want to close this window?");
            int retVal = confirmation.Run ();
            confirmation.Destroy ();
            if (retVal == -8)
            {
                e.RetVal = false;
            }
            else if (retVal == -9)
            {
                e.RetVal = true;
            }
            else
            {
                throw new NotImplementedException ();
            }
        }

        /// <summary>
        /// Simplified function to show warning message with secondary text.
        /// </summary>
        /// <param name="primaryText">Primary text.</param>
        /// <param name="secondaryText">Secondary text.</param>
        protected void showWarning (string primaryText, string secondaryText)
        {
            MessageDialog warning = new MessageDialog (this,
                                                       DialogFlags.DestroyWithParent,
                                                       MessageType.Error,
                                                       ButtonsType.Close,
                                                       primaryText);
            if (secondaryText != null)
            {
                warning.SecondaryText = secondaryText;
            }
            warning.Run ();
            warning.Destroy ();
        }

        /// <summary>
        /// Simplified function to show warning message without secondary text.
        /// </summary>
        /// <param name="text">Text.</param>
        protected void showWarning (string text)
        {
            showWarning (text, null);
        }
    }
}

