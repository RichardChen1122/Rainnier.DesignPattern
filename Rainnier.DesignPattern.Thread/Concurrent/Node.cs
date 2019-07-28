using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.Concurrent
{
    internal class Node<T>
    {
        private Node<T> _next;
        private T _data;

        public Node<T> Next
        {
            get { return _next; }
            set { _next = value; }
        }
        

        public T Data
        {
            get { return _data; }
            set { _data = value; }
        }

        public Node(T data)
        {
            _data = data;
        }

    }
}
