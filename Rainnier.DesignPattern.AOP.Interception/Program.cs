using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AOP.Interception
{
    class Program
    {
        static void Main(string[] args)
        {
            // The code provided will print ‘Hello World’ to the console.
            // Press Ctrl+F5 (or go to Debug > Start Without Debugging) to run your app.
            Console.WriteLine("Hello World!");
            Console.WriteLine(new Calc().add(1, 0));
            Console.WriteLine(new Calc().add(2, 3));
            Console.WriteLine(new Calc().add(1, 1));
            Console.ReadKey();

            // Go to http://aka.ms/dotnet-get-started-console to continue learning how to build a console app! 
        }
    }

    [AOP]
    public class Calc: ContextBoundObject
    {
        [AOPMethod]
        [HandleMethod]
        public int add(int a, int b)
        {
            return a + b;
        }
    }
}
