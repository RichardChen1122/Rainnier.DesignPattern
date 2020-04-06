using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ClassicPattern.ReaderWriter
{
    //在此算法中，读进程是优先的，简单来讲，当存在读者进程时，写者操作将被延迟，
    //并且只要有一个读者进程活跃，随后而来的读者进程都将被允许访问文件。
    //这样的方式下，会导致写者进程可能长时间等待，且存在写者进程“饿死”的情况。
    class ReadFirst
    {
        class Program
        {

            private static Semaphore RWMutex;  // 读写互斥信号量
            private static Semaphore CountMutex;  //读者计数互斥信号量
            private static int Rcount = 0;  // 正在进行读操作的读者数目
            static void Main(string[] args)
            {
                RWMutex = new Semaphore(1, 1);
                CountMutex = new Semaphore(1, 1);
                Thread Writer = new Thread(writer);
                Thread Reader0 = new Thread(reader);
                Thread Reader1 = new Thread(reader);
                Thread Reader2 = new Thread(reader);
                Writer.Start();
                Reader0.Start();
                Reader1.Start();
                Reader2.Start();
            }
            //写者进程
            protected static void writer()
            {
                while (true)
                {
                    RWMutex.WaitOne();  // 判断是否可以写
                    Console.WriteLine("write");
                    Thread.Sleep(1000);
                    RWMutex.Release();  // 写完成，释放资源
                }
            }
            //读者进程
            protected static void reader()
            {
                while (true)
                {
                    CountMutex.WaitOne();  // 互斥访问count变量
                    Rcount++;
                    if (Rcount == 1)  // 第一个读进程占用写进程的资源
                    {
                        RWMutex.WaitOne();
                    }
                    CountMutex.Release();
                    Console.WriteLine("read-" + Rcount);
                    Thread.Sleep(1000);
                    CountMutex.WaitOne();
                    Rcount--;
                    if (Rcount == 0)  // 最后一个读进程释放写进程的资源
                    {
                        RWMutex.Release();//只有当没有读进程的时候才会释放,势必导致写进程饥饿
                    }
                    CountMutex.Release();
                }
            }
        }

    }
}
