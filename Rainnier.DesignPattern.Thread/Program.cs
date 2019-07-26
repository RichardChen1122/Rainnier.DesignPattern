using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync
{
    class Program
    {
        static volatile int ticketCount = 10;
        static void Main(string[] args)
        {
            var t1 = new Thread(SellTicket)
            {
                Name = "Windows1"
            };
            var t2 = new Thread(SellTicket);
            t2.Name = "Windows2";
            var t3 = new Thread(SellTicket);
            t3.Name = "Windows3";

            t1.Start();
            t2.Start();
            t3.Start();

            Console.ReadKey();

        }

        static void SellTicket()
        {
            //while (Interlocked.CompareExchange(ref ticketCount,0,0)>0)
            while (ticketCount > 0)
            {
                Console.WriteLine($"{Thread.CurrentThread.Name} currently have {ticketCount} ticket");
                Interlocked.Decrement(ref ticketCount);
                //ticketCount--;

                Console.WriteLine($"{Thread.CurrentThread.Name} sold 1 ticket. left {ticketCount}");
            }
        }
    }
}
