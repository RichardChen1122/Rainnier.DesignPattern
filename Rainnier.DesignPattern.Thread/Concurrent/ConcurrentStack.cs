using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.Concurrent
{
    internal class ConcurrentStack
    {
        Node<int> _head;

        public Node<int> Head
        {
            get { return _head; }
            set { _head = value; }
        }

        public ConcurrentStack(Node<int> head)
        {
            _head = head;
        }

        public void Push(int newdata)
        {
            Node<int> newNode = new Node<int>(newdata);

            newNode.Next = _head;
            Thread.Sleep(1);
            //_head = newNode;

            while (Interlocked.CompareExchange(ref _head, newNode, newNode.Next) != newNode.Next)
            {
                //spin.SpinOnce();
                // Reread the head and link our new node.
                newNode.Next = _head;
            }

            //PushCore(newNode);
        }

        private void PushCore(Node<int> head)
        {
            SpinWait spin = new SpinWait();

            // Keep trying to CAS the exising head with the new node until we succeed.
            do
            {
                spin.SpinOnce();
                // Reread the head and link our new node.
                head.Next = _head;
            }
            while (Interlocked.CompareExchange(ref _head, head, head.Next) != head.Next) ;
        }
    }
}
