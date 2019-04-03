using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractEncrptyFacade f = new EncrptyFacade();

            f.Encrypt("text.txt", "out.txt");

            Console.ReadKey();
        }
    }
}
