using System;
using Gtk;

namespace KeyRegisterApp
{
    public class KeyView : OwnScrolledTreeView
    {
        public KeyView (KeyRegister kr) : base(kr)
        {
            TreeViewColumn keyDbIdColumn = new TreeViewColumn ();

            TreeViewColumn statusColumn = new TreeViewColumn ();
            statusColumn.Title = "";

            TreeViewColumn idColumn = new TreeViewColumn ();
            idColumn.Title = "Identifier";
            keyIdColumnIndex = 1;

            TreeViewColumn nameColumn = new TreeViewColumn ();
            nameColumn.Title = "Name";

            TreeViewColumn descriptionColumn = new TreeViewColumn ();
            descriptionColumn.Title = "Description";
            
            tree.AppendColumn (keyDbIdColumn);
            tree.AppendColumn (statusColumn);
            tree.AppendColumn (idColumn);
            tree.AppendColumn (nameColumn);
            tree.AppendColumn (descriptionColumn);

            CellRendererText statusCell = new CellRendererText ();
            statusColumn.PackStart (statusCell, true);
            CellRendererText identifierCell = new CellRendererText ();
            idColumn.PackStart (identifierCell, true);
            CellRendererText nameCell = new CellRendererText ();
            nameColumn.PackStart (nameCell, true);
            CellRendererText descriptionCell = new CellRendererText ();
            descriptionColumn.PackStart (descriptionCell, true);

            statusColumn.AddAttribute (statusCell, "text", 1);
            idColumn.AddAttribute (identifierCell, "text", 2);
            nameColumn.AddAttribute (nameCell, "text", 3);
            descriptionColumn.AddAttribute (descriptionCell, "text", 4);

            statusColumn.MaxWidth = 30;
            idColumn.MaxWidth = 100;
            nameColumn.MaxWidth = 100;
            descriptionColumn.MaxWidth = 200 - statusColumn.MaxWidth;

            listStore = new ListStore (typeof(int),
                                       typeof(string),
                                       typeof(string),
                                       typeof(string),
                                       typeof(string));
            tree.Model = listStore;
        }

        protected override void rowDoubleClicked (object o, EventArgs e)
        {

        }

        public override void addValues (object[] values)
        {
            listStore.Clear ();
            foreach (Key value in values)
            {
                // Setting key status.
                string status = "A";
                if (value.IsMissing)
                {
                    status = "M";
                }
                else if (keyRegister.getActiveLoanByKeyId (value.DbId) != null)
                {
                    status = "L";
                }

                listStore.AppendValues (value.DbId,
                                        status,
                                        value.Identifier,
                                        value.Name,
                                        value.Description);
            }
        }
    }
}

