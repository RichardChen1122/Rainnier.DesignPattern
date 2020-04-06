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
        //信号量的值被设置成正数，则它等于发出semWait 操作后可继续执行的线程的数量（立即执行）。若值为0， 那么发出semWait
        //操作的下一个线程会被阻塞，此时该信号量的值变为负值。之后，每个后续的semWait
        //操作会使信号量的负值跟打，该负值等于正在等待解除阻塞的线程的数量
        //在信号量为负值的情况下，每个semSignal操作都会将等待进程中的一个线程解除阻塞
        static Semaphore sema = new Semaphore(2,2);
        //static SemaphoreSlim sema = new SemaphoreSlim(2,2);

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
