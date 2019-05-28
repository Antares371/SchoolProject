using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib.Collection.Reporting
{
    public class ReportingCollectionEventArgs : CancelEventArgs
    {
        public object Item { get; private set; }
        public ReportingCollectionAction Action { get; private set; }

        public ReportingCollectionEventArgs(object item, ReportingCollectionAction action)
        {
            Item = item;
            Action = action;
        }
    }
}
