using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ClassicPattern.ProducerComsumer
{
    class StartUp
    {
        private static Queue<ItemModel> queue = new Queue<ItemModel>();
        private static ConcurrentQueue<ItemModel> concurrentQueue = new ConcurrentQueue<ItemModel>();

        private static Semaphore sema = new Semaphore(1, 1);

        static void Main(string[] args)
        {
            var t1 = new Thread(Produce);
            t1.Name = "Producer1";
            var t2 = new Thread(Produce);
            t2.Name = "Producer2";
            var t3 = new Thread(Produce);
            t3.Name = "Producer3";

            var t4 = new Thread(Consume);
            t4.Name = "Consumer1";
            var t5 = new Thread(Consume);
            t5.Name = "Consumer2";
            var t6 = new Thread(Consume);
            t6.Name = "Consumer3";

            t1.Start();
            t2.Start();
            t3.Start();
            t4.Start();
            t5.Start();
            t6.Start();
        }

        private static void Produce()
        {
            while (true)
            {
                sema.WaitOne();
                queue.Enqueue(new ItemModel()
                {
                    Guid = Guid.NewGuid().ToString()
                });
                //Thread.Sleep(10);
                Console.WriteLine($"Produce: {Thread.CurrentThread.Name} produce an item ");
                sema.Release();
            }
        }

        private static void Consume()
        {
            while (true)
            {
                sema.WaitOne();
                if (queue.Count>0)
                {
                    var result = queue.Dequeue();
                    Console.WriteLine($"Consumer: {Thread.CurrentThread.Name} consume an item {result.Guid} ");
                }
                sema.Release();
            }
        }
    }
}
