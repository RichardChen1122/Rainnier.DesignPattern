using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode
{
    //内核锁：基于内核对象构造的锁机制，就是通常说的内核构造模式。用户模式构造和内核模式构造
    //       优点：cpu利用最大化。它发现资源被锁住，请求就排队等候。线程切换到别处干活，直到接受到可用信号，线程再切回来继续处理请求。
    //       缺点：托管代码->用户模式代码->内核代码损耗、线程上下文切换损耗。
    //               在锁的时间比较短时，系统频繁忙于休眠、切换，是个很大的性能损耗。
    //自旋锁：原子操作+自循环。通常说的用户构造模式。  线程不休眠，一直循环尝试对资源访问，直到可用。
    //       优点：完美解决内核锁的缺点。
    //       缺点：长时间一直循环会导致cpu的白白浪费，高并发竞争下、CPU的消耗特别严重。
    //混合锁：内核锁+自旋锁。 混合锁是先自旋锁一段时间或自旋多少次，再转成内核锁。
    //       优点：内核锁和自旋锁的折中方案，利用前二者优点，避免出现极端情况（自旋时间过长，内核锁时间过短）。
    //       缺点： 自旋多少时间、自旋多少次，这些策略很难把控。
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
