using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ClassicPattern.ReaderWriter
{
    class WriteFirst
    {
        private static Semaphore RCMutex, WCMutex ;  // 读者、写者计数互斥
        private static Semaphore extra; //这个额外的信号量很关键。在rsem 上不允许建造长队列，否则写进程将无法跳过这个队列，因此只允许一个读进程在rsem 上排队，其他读进程在等待rsem 时，在extra 上排队
        private static Semaphore rsem, wsem;  // 读写互斥
        private static int readCount = 0, writeCount = 0;  // 读者、写者计数

        static void Main(string[] args)
        {
            RCMutex = new Semaphore(1, 1);
            WCMutex = new Semaphore(1, 1);
            extra = new Semaphore(1, 1);
            rsem = new Semaphore(1, 1);
            wsem = new Semaphore(1, 1);
            Thread Writer = new Thread(writer);
            Thread Reader0 = new Thread(reader);
            Thread Reader1 = new Thread(reader);
            Thread Reader2 = new Thread(reader);
            Writer.Start();
            Reader0.Start();
            Reader1.Start();
            Reader2.Start();
        }

        protected static void writer()
        {
            while (true)
            {
                WCMutex.WaitOne();
                writeCount++;
                if (writeCount == 1)
                {
                    rsem.WaitOne();
                }
                WCMutex.Release();

                wsem.WaitOne();
                Console.WriteLine("write");
                Thread.Sleep(1000);
                wsem.Release();

                WCMutex.WaitOne();
                writeCount--;
                if (writeCount == 0)
                {
                    rsem.Release(); //只有当Wirte 为0 的时候，才能释放写信号
                }
                WCMutex.Release();
            }
        }

        protected static void reader()
        {
            while (true)
            {
                extra.WaitOne();
                rsem.WaitOne();
                RCMutex.WaitOne();
                readCount++;
                if (readCount == 1)
                {
                    wsem.WaitOne();
                }

                RCMutex.Release();
                rsem.Release();
                extra.Release();
                Console.WriteLine("read-" + readCount);
                RCMutex.WaitOne();
                readCount--;
                if (readCount == 0)
                {
                    wsem.Release();
                }
                RCMutex.Release();
            }
        }
    }
}
