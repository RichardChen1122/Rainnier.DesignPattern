using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            var pro = Product.GetInstance();
            Console.ReadKey();
        }
    }
}
