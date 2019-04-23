using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class SinglyLinkedList<T>
    {
        private ListItem<T> Head
        {
            get;
            set;
        }

        private int Count
        {
            get;
            set;
        }

        public SinglyLinkedList(int count, ListItem<T> head)
        {
            if (count < 0)
            {
                throw new ArgumentException("count must be >= 0", nameof(count));
            }

            Count = count;
            Head = head;
        }

        public int GetSize()
        {
            return Count;
        }

        public T GetFirstElement()
        {
            return Head.GetData();
        }

        public T GetElementByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < size of list");
            }

            int count = -1;

            T element = default(T);
            for (ListItem<T> p = Head; p != null; p = p.GetNext())
            {
                count++;
                if (count == index)
                {
                    element = p.GetData();
                }
            }
            return element;
        }

        public T SetElementByIndex(int index, T element)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < size of list");
            }

            int count = -1;

            T oldElement = default(T);
            for (ListItem<T> p = Head; p != null; p = p.GetNext())
            {
                count++;
                if (count == index)
                {
                    oldElement = p.GetData();
                    p.SetData(element);
                }
            }

            return oldElement;
        }

        public T RemoveItemByIndex(int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < size of list");
            }

            int count = -1;

            T element = default(T);
            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.GetNext())
            {
                if (count == index - 1)
                {
                    element = p.GetData();
                    prev.SetNext(p.GetNext());
                }

                count++;
            }

            if (count == -1)
            {
                Head = Head.GetNext();
            }
            Count--;

            return element;
        }

        public void SetItemToBegin(ListItem<T> item)
        {
            Head = item;
            Count++;
        }

        public void SetItemByIndex(ListItem<T> item, int index)
        {
            if (index >= Count || index < 0)
            {
                throw new IndexOutOfRangeException("index must be >= 0 and < size of list");
            }

            int count = -1;

            for (ListItem<T> p = Head, prev = null; p != null; prev = p, p = p.GetNext())
            {
                if (count == index - 1)
                {
                    item.SetNext(p.GetNext());
                    prev.SetNext(item);
                }
                count++;
            }

            if (count == -1)
            {
                Head = item;
            }

            Count++;
        }

        public bool RemoveItemByData(T data)
        {
            bool itemRemoved = false;
            ListItem<T> prev = null;

            for (ListItem<T> p = Head; p != null; prev = p, p = p.GetNext())
            {
                if (p.GetData().Equals(data))
                {
                    itemRemoved = true;
                    prev.SetNext(p.GetNext());
                }
            }

            if (prev == null)
            {
                Head = Head.GetNext();
            }
            Count--;

            return itemRemoved;
        }

        public T RemoveFirstItem()
        {
            T firstElement = Head.GetData();
            Head = Head.GetNext();

            Count--;

            return firstElement;
        }

        public SinglyLinkedList<T> GetTurn()
        {
            SinglyLinkedList<T> turnedList = new SinglyLinkedList<T>(Count, Head);

            for (ListItem<T> p = Head.GetNext(); p != null; p = p.GetNext())
            {
                turnedList.SetItemToBegin(p);
            }

            return turnedList;
        }

        public SinglyLinkedList<T> GetCopy()
        {
            SinglyLinkedList<T> listCopy = new SinglyLinkedList<T>(Count, Head);

            for (ListItem<T> p = Head.GetNext(); p != null; p = p.GetNext())
            {
                listCopy.SetItemToBegin(p);
            }

            listCopy.GetTurn();

            return listCopy;
        }

        public void PrintList()
        {
            for (ListItem<T> p = Head; p != null; p = p.GetNext())
            {
                Console.WriteLine(p.GetData());
            }
        }
    }
}






