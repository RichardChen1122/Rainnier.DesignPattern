using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode
{
    class Program
    {
        // 初始化自动重置事件，并把状态设置为非终止状态
        public static AutoResetEvent autoEvent = new AutoResetEvent(false);

        //public static ManualResetEvent autoEvent = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main Thread Start run at: " + DateTime.Now.ToLongTimeString());
            Thread t = new Thread(TestMethod);
            t.Start();
            Thread.Sleep(3000);
            autoEvent.Set();
            Thread.Sleep(3000);
            autoEvent.Set();
            Console.Read();
        }

        public static void TestMethod()
        {
            // 初始状态为终止状态，则第一次调用WaitOne方法不会堵塞线程
            // 此时运行的时间间隔应该为0秒，但是因为是AutoResetEvent对象
            // 调用WaitOne方法后立即把状态返回为非终止状态。
            autoEvent.WaitOne();
            Console.WriteLine("Method start at : " + DateTime.Now.ToLongTimeString());



            // 因为此时AutoRestEvent为非终止状态，所以调用WaitOne方法后将阻塞线程1秒，这里设置了超时时间
            // 所以下面语句的和主线程中语句的时间间隔为1秒
            // 当时 ManualResetEvent对象时，因为不会自动重置状态
            // 所以调用完第一次WaitOne方法后状态仍然为非终止状态,所以再次调用不会阻塞线程，所以此时的时间间隔也为0
            // 如果没有设置超时时间的话，下面这行语句将不会执行
            autoEvent.WaitOne();
            Console.WriteLine("Method start at : " + DateTime.Now.ToLongTimeString());


        }
    }
}
