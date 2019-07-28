using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Rainnier.DesignPattern.ThreadSync.Concurrent;

namespace Rainnier.DesignPattern.ThreadSync
{
    class Program
    {
        static volatile int ticketCount = 5;
        static volatile bool soleout = false;
        static void Main(string[] args)
        {
            var node1 = new Node<int>(1);
            var node2 = new Node<int>(2);
            var node3 = new Node<int>(3);
            node1.Next = node2;
            node2.Next = node3;
            var stack = new ConcurrentStack(node1);

            

            var node4 = new Node<int>(4);
            var node5 = new Node<int>(5);
            var node6 = new Node<int>(6);
            var node7 = new Node<int>(7);
            var node8 = new Node<int>(8);

            var node9 = new Node<int>(9);
            var node10 = new Node<int>(10);

            //var t1 = new Thread(() => stack.Push(4));
            //t1.Name = "Windows1";
            //var t2 = new Thread(() => stack.Push(5));
            //t2.Name = "Windows2";
            //var t3 = new Thread(() => stack.Push(6));
            //t3.Name = "Windows3";
            //var t4 = new Thread(() => stack.Push(7));
            //t4.Name = "Windows4";
            //var t5 = new Thread(() => stack.Push(8));
            //t5.Name = "Windows5";
            //var t6 = new Thread(() => stack.Push(9));
            //t6.Name = "Windows6";
            //var t7 = new Thread(() => stack.Push(10));
            //t7.Name = "Windows7";

            var t1 = new Thread(SellTicket);
            t1.Name = "Windows1";
            var t2 = new Thread(SellTicket);
            t2.Name = "Windows2";
            var t3 = new Thread(SellTicket);
            t3.Name = "Windows3";
            var t4 = new Thread(SellTicket);
            t4.Name = "Windows4";
            var t5 = new Thread(SellTicket);
            t5.Name = "Windows5";
            var t6 = new Thread(SellTicket);
            t6.Name = "Windows6";
            var t7 = new Thread(SellTicket);
            t7.Name = "Windows7";

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
            t7.Start();

            Thread.Sleep(1000);
            PrintStack(stack);

            Console.ReadKey();

        }



        static void SellTicket()
        {
            //CSA 比较并交换， 是解决多线程并行情况下使用锁造成性能损耗的一种机制，CAS 操作包括三个操作数 、
            //-- 要更新的变量V 预期原值E 和 新值N
            //Interlocked.CompareExchange(ref E,N,V)
            //如果E 和V不相等，什么都不做
            //如果E 和V相等，则用N 替换 E 的值，不管比较结果 return 的都是E的原值,注意 E 是按址传递的。
            var current = ticketCount;
            SpinWait spin = new SpinWait();
            while (current > 0)
            {
                Thread.Sleep(10);
                if (Interlocked.CompareExchange(ref ticketCount, ticketCount-1, current) != current)
                {
                    spin.SpinOnce();
                    current = ticketCount;
                }
                else
                {
                    Console.WriteLine($"{Thread.CurrentThread.Name} sold 1 ticket. left {ticketCount}");
                    return;
                }

            }
        
            //以下是最开始有问题的方法，在作判断是否大于0时，会出现非预期的结果
            //if (ticketCount > 0)
            //{
            //    Console.WriteLine($"{Thread.CurrentThread.Name} currently have {ticketCount} ticket");
            //    Thread.Sleep(1);
            //    Interlocked.Decrease(ref ticketCount);
            //    Console.WriteLine($"{Thread.CurrentThread.Name} sold 1 ticket. left {ticketCount}");
            //}
        }

        static void PrintStack(ConcurrentStack stack)
        {
            var head = stack.Head;

            while (head != null)
            {
                Console.WriteLine(head.Data);
                head = head.Next;
            }
        }
    }
}
