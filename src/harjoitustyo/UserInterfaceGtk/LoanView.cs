using System;
using Gtk;

namespace KeyRegisterApp
{
    public class LoanView : OwnScrolledTreeView
    {
        public LoanView (KeyRegister kr) : base(kr)
        {
            TreeViewColumn loanDbIdColumn = new TreeViewColumn ();

            TreeViewColumn keyIdColumn = new TreeViewColumn ();
            keyIdColumn.Title = "Key";
            keyIdColumnIndex = 0;

            TreeViewColumn startDateColumn = new TreeViewColumn ();
            startDateColumn.Title = "Start date";
            
            TreeViewColumn dueDateColumn = new TreeViewColumn ();
            dueDateColumn.Title = "Due date";
            
            TreeViewColumn loanedToColumn = new TreeViewColumn ();
            loanedToColumn.Title = "Loaned to";
            
            tree.AppendColumn (loanDbIdColumn);
            tree.AppendColumn (keyIdColumn);
            tree.AppendColumn (startDateColumn);
            tree.AppendColumn (dueDateColumn);
            tree.AppendColumn (loanedToColumn);

            CellRendererText keyIdCell = new CellRendererText ();
            keyIdColumn.PackStart (keyIdCell, true);
            CellRendererText startDateCell = new CellRendererText ();
            startDateColumn.PackStart (startDateCell, true);
            CellRendererText dueDateCell = new CellRendererText ();
            dueDateColumn.PackStart (dueDateCell, true);
            CellRendererText loanedToCell = new CellRendererText ();
            loanedToColumn.PackStart (loanedToCell, true);

            keyIdColumn.AddAttribute (keyIdCell, "text", 1);
            startDateColumn.AddAttribute (startDateCell, "text", 2);
            dueDateColumn.AddAttribute (dueDateCell, "text", 3);
            loanedToColumn.AddAttribute (loanedToCell, "text", 4);
            /*keyIdColumn.MaxWidth = 100;
            startDateColumn.MaxWidth = 100;
            dueDateColumn.MaxWidth = 200;*/

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
            foreach (Loan value in values)
            {
                string startDate = value.parseStartDate () [2].ToString () + "." +
                                   value.parseStartDate () [1].ToString () + "." +
                                   value.parseStartDate () [0].ToString ();
                string dueDate = null;
                if (value.parseDueDate () != null) {
                    dueDate = value.parseDueDate () [2].ToString () + "." +
                              value.parseDueDate () [1].ToString () + "." +
                              value.parseDueDate () [0].ToString ();
                }

                listStore.AppendValues (value.LoanDbId,
                                        keyRegister.getKeyById(value.KeyId).Identifier,
                                        startDate,
                                        dueDate,
                                        value.LoanedTo);
            }
        }
    }
}

