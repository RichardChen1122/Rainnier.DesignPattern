using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            var w = new Window();
            var s = new ScrollBar();
            w.AddDecorator(s);

            w.Display();
            Console.ReadKey();
        }
    }
}
