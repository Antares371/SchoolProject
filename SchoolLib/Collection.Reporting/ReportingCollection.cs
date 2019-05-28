using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLib.Collection.Reporting
{
    public class ReportingCollection<T> : IEnumerable<T>
    {
        private List<T> items;

        public event CollectionChangeEventHandler BeforeCollectionChange;
        public event CollectionChangeEventHandler AfterCollectionChanged;
        public T this[int index]
        {
            get { return items[index]; }
            set
            {
                ReportingCollectionEventArgs eBefore = new ReportingCollectionEventArgs(value, ReportingCollectionAction.Edit);
                OnBeforeCollectionChaneg(eBefore);
                if(eBefore.Cancel)
                    return;

                items[index] = value;

                ReportingCollectionEventArgs eAfter = new ReportingCollectionEventArgs(value, ReportingCollectionAction.Edit);
                OnBeforeCollectionChaneg(eAfter);

            }
        }

        public int Count { get { return items.Count; } }
        public bool IsReadOnly { get { return false; } }

        public ReportingCollection()
        {
            items = new List<T>();
        }

        public void Add(T item)
        {
            ReportingCollectionEventArgs e = new ReportingCollectionEventArgs(item, ReportingCollectionAction.Add);
            OnBeforeCollectionChaneg(e);
            if(e.Cancel)
                return;
            items.Add(item);
            ReportingCollectionEventArgs afterE = new ReportingCollectionEventArgs(items, ReportingCollectionAction.Add);
            OnAfterCollectionChaneg(afterE);
        }

        public void Clear()
        {
            ReportingCollectionEventArgs e = new ReportingCollectionEventArgs(items, ReportingCollectionAction.Remove);
            OnBeforeCollectionChaneg(e);
            if(e.Cancel)
                return;

            items.Clear();

            ReportingCollectionEventArgs afterE = new ReportingCollectionEventArgs(items, ReportingCollectionAction.Remove);
            OnAfterCollectionChaneg(afterE);
        }

        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            items.CopyTo(array);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return items.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            ReportingCollectionEventArgs e = new ReportingCollectionEventArgs(item, ReportingCollectionAction.Add);
            OnBeforeCollectionChaneg(e);
            if(e.Cancel)
                return;

            items.Insert(index, item);

            ReportingCollectionEventArgs afterE = new ReportingCollectionEventArgs(items, ReportingCollectionAction.Remove);
            OnAfterCollectionChaneg(afterE);
        }

        public bool Remove(T item)
        {
            ReportingCollectionEventArgs e = new ReportingCollectionEventArgs(item, ReportingCollectionAction.Remove);
            OnBeforeCollectionChaneg(e);
            if(e.Cancel)
                return false;
            return items.Remove(item);
        }

        public void RemoveAt(int index)
        {
            ReportingCollectionEventArgs e = new ReportingCollectionEventArgs(items[index], ReportingCollectionAction.Remove);
            OnBeforeCollectionChaneg(e);
            if(e.Cancel)
                return;

            items.RemoveAt(index);

            ReportingCollectionEventArgs afterE = new ReportingCollectionEventArgs(items, ReportingCollectionAction.Remove);
            OnAfterCollectionChaneg(afterE);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void OnBeforeCollectionChaneg(ReportingCollectionEventArgs e)
        {
            if(BeforeCollectionChange == null)
                return;
            BeforeCollectionChange(this, e);
        }

        private void OnAfterCollectionChaneg(ReportingCollectionEventArgs e)
        {
            if(AfterCollectionChanged == null)
                return;
            AfterCollectionChanged(this, e);
        }
    }
}
