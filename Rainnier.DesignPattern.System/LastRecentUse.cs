using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.System
{
    class LastRecentUse
    {

    }

    class TwoWayLinkList
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; set; }

        private int capcity;

        public TwoWayLinkList(int capcity)
        {
            this.capcity = capcity;
        }

        public void AddToTail(Node item)
        {

            Tail.Next = item;
            item.Previous = Tail;
            Tail = item;
            Count++;

            if (Count > capcity)
            {
                RemoveHead();
            }
        }



        public void RemoveHead()
        {
            Head = Head.Next;
            Head.Previous = null;
            Count--;
        }
    }

    class Node
    {
        public int Data { get; set; }
        public Node Next { get; set; }
        public Node Previous { get; set; }
    }
}
