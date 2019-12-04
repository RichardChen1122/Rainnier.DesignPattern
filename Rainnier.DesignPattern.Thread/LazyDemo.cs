using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync
{
    public class LazyDemo
    {
        static void Main(string[] args)
        {
            Lazy<DateTime> time = new Lazy<DateTime>(() => DateTime.Now);

            Console.WriteLine(time.IsValueCreated);
            Console.WriteLine(time.Value);
            Console.WriteLine(time.IsValueCreated);
            Console.WriteLine(time.Value);

            Console.ReadKey();
        }
    }
}
