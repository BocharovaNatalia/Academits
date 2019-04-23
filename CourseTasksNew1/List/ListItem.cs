using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class ListItem<T>
    {
        private T Data
        {
            get;
            set;
        }

        private ListItem<T> Next
        {
            get;
            set;
        }

        public ListItem(T data)
        {
            Data = data;
        }

        public ListItem(T data, ListItem<T> next)
        {
            Data = data;
            Next = next;
        }

        public T GetData()
        {
            return Data;
        }

        public ListItem<T> GetNext()
        {
            return Next;
        }

        public void SetData(T value)
        {
            Data = value;
        }

        public void SetNext(ListItem<T> value)
        {
            Next = value;
        }
    }
}
