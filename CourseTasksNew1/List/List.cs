using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class List
    {
        static void Main(string[] args)
        {
            ListItem<Int32> item1 = new ListItem<Int32>(1, null);
            ListItem<Int32> item2 = new ListItem<Int32>(2, item1);
            ListItem<Int32> item3 = new ListItem<Int32>(3, item2);
            ListItem<Int32> item4 = new ListItem<Int32>(4, item3);
            ListItem<Int32> item5 = new ListItem<Int32>(5, item4);

            SinglyLinkedList<Int32> list = new SinglyLinkedList<Int32>(5, item5);

            list.PrintList();

            Console.WriteLine(list.GetSize());

            Console.WriteLine(list.GetFirstElement());

            Console.WriteLine(list.GetElementByIndex(4));

            list.SetElementByIndex(1, 3);
            list.PrintList();

            list.RemoveItemByIndex(1);
            list.PrintList();

            list.RemoveItemByData(1);
            list.PrintList();

            list.GetCopy();
            list.PrintList();
        }
    }
}
