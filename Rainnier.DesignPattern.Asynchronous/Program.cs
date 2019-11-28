using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous
{
    class Program
    {
        static void Main(string[] args)
        {
            var dedicatedThread = new Thread(ComputeBountOp);
            dedicatedThread.Start(5);

            Console.WriteLine("Main thread: doing other work here...");
            Thread.Sleep(10000);

            dedicatedThread.Join();
            Console.WriteLine("Hit <enter> to exit...");
            Console.ReadLine();
            //List<TestEntity> test = new List<TestEntity>();
            //List<Task> tasks = new List<Task>();
            //test.Add(new TestEntity() { dbName = "db1", time = 11 });
            //test.Add(new TestEntity() { dbName = "db2", time = 10 });
            //test.Add(new TestEntity() { dbName = "db3", time = 9 });
            //test.Add(new TestEntity() { dbName = "db4", time = 8 });
            //test.Add(new TestEntity() { dbName = "db5", time = 7 });
            //test.Add(new TestEntity() { dbName = "db6", time = 6 });
            //test.Add(new TestEntity() { dbName = "db7", time = 5 });
            //test.Add(new TestEntity() { dbName = "db8", time = 4 });
            //test.Add(new TestEntity() { dbName = "db9", time = 3 });
            //test.Add(new TestEntity() { dbName = "db10", time = 2 });
            //foreach(var a in test)
            //{
            //    Task.Run(() => TestClass.DoInsertInDatabase(a.dbName, a.time)).
            //        ContinueWith(m => { Console.WriteLine($"{a.dbName} done"); });
            //}

            using (ManualResetEventSlim finishEvent = new ManualResetEventSlim(true))
            {
                List<int> tempResult = null;
                var thread = new Thread(() =>
                {
                    tempResult = TestClass.DoSeachInDatabase();
                    finishEvent.Set();
                });
                thread.Start();
                
                int t = 10;
                while (t > 0)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("doing something else");
                    t--;
                }
                finishEvent.Wait(10000);
                Console.WriteLine(tempResult.Count);
            }

            Console.ReadKey();


        }

        private static void ComputeBountOp(Object state)
        {
            Console.WriteLine("In ComputeBountOp:{0}", state);
            Thread.Sleep(2000);
        }
    }

    public class TestEntity
    {
        public int time { get; set; }
        public string dbName { get; set; }
    }
}
