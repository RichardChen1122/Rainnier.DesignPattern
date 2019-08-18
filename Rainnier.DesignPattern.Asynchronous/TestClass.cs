using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous
{
    public class TestClass
    {
        public static List<int> DoSeachInDatabase()
        {
            Thread.Sleep(5000);
            return Enumerable.Range(0, 100).ToList();
        }

        public static void DoInsertInDatabase(string db, int time)
        {
            int i = 0;
            while (i < time*1000)
            {
                Thread.Sleep(500);
                Console.WriteLine($"Doing insert action in databse {db} in Thread {Thread.CurrentThread.ManagedThreadId}");
                
                i += 500;

            }

        }

    }

    
}
