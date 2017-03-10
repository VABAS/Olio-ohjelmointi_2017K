using System;
using Gtk;

namespace KeyRegisterApp
{
    public abstract class OwnScrolledTreeView : ScrolledWindow
    {
        protected ListStore listStore;
        protected TreeView tree;
        //protected string selectedKeyIdentifier;
        protected int keyIdColumnIndex;
        protected int selectedDbId;

        protected KeyRegister keyRegister;

        //public string SelectedKeyIdentifier {
        //    get { return selectedKeyIdentifier; }
        //}

        public int SelectedDbId {
            get { return selectedDbId; }
        }
        public OwnScrolledTreeView (KeyRegister kr)
        {
            keyRegister = kr;

            tree = new TreeView ();

            tree.RowActivated += rowDoubleClicked;
            tree.CursorChanged += rowSelected;

            Add (tree);

        }

        public void rowSelected (object o, EventArgs e)
        {
            if (tree.Selection.CountSelectedRows() > 1)
            {
                throw new InvalidSelectionException ("Too many rows selected!");
            }
            TreeSelection selection = (o as TreeView).Selection;
            ITreeModel model;
            TreeIter iter;

            if(selection.GetSelected(out model, out iter)){
                //selectedKeyIdentifier = model.GetValue (iter, 1).ToString ();
                selectedDbId = int.Parse(model.GetValue (iter, 0).ToString());
            }
        }

        protected abstract void rowDoubleClicked (object o, EventArgs e);

        public abstract void addValues (object[] values);

        public class InvalidSelectionException : System.Exception
        {
            public InvalidSelectionException() : base() { }
            public InvalidSelectionException(string message) : base(message) { }
        }
    }
}

