using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode
{
    public class SemaphoreDemo
    {
        static Semaphore sema = new Semaphore(2,2);

        static void Main(string[] args)
        {
            for (int i = 0; i < 3; i++)
            {
                var thread = new Thread(Test) { Name = $"Thread{ i }" };
                thread.Start();
            }
            Console.ReadKey();
        }


        static void Test()
        {
            //如果线程已经到达了最大量，那么阻塞
            sema.WaitOne();
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"ThreadName:{ Thread.CurrentThread.Name} i:{i}");
                Thread.Sleep(1000);
            }
            //执行结束以后释放， 以待后续线程可以进入
            sema.Release();
            Console.ReadKey();
        }
    }
}
