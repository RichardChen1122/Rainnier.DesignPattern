using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ClassicPattern.ReaderWriter
{
    class ReadWriteJinzheng
    {
        //
        private static Semaphore RCMutex, WCMutex, RMutex, WMutex;
        private static int Rcount = 0;
        static void Main(string[] args)
        {
            RCMutex = new Semaphore(1, 1);
            WCMutex = new Semaphore(1, 1);
            RMutex = new Semaphore(1, 1);
            WMutex = new Semaphore(1, 1);
            Thread Writer0 = new Thread(writer);
            Thread Reader0 = new Thread(reader);
            Thread Reader1 = new Thread(reader);
            Thread Reader2 = new Thread(reader);

            Reader0.Start();
            Writer0.Start();
            //Reader1.Start();
            //Reader2.Start();
        }
        public static void reader()
        {
            while (true)
            {
                Console.WriteLine("reader waiting");
                RMutex.WaitOne();
                RCMutex.WaitOne();
                Rcount++;
                if (Rcount == 1)
                {
                    WMutex.WaitOne();
                }
                RCMutex.Release();
                Console.WriteLine("read-" + Rcount);
                Thread.Sleep(1000);
                RCMutex.WaitOne();
                Rcount--;
                if (Rcount == 0)
                {
                    WMutex.Release();
                }
                RCMutex.Release();
                RMutex.Release();
            }
        }
        public static void writer()
        {
            while (true)
            {
                Console.WriteLine("Writer waiting");
                RMutex.WaitOne();
                WMutex.WaitOne();
                Console.WriteLine("write");
                Thread.Sleep(1000);
                WMutex.Release();
                RMutex.Release();
            }
        }

    }
}
