using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.FlyWeight
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = FlyweightFactory.GetInstance();

            var chess1 = factory.GetChess("white");
            var chess2 = factory.GetChess("white");
            var chess3 = factory.GetChess("black");

            chess1.Display(new Coordinate(1, 2));
            chess2.Display(new Coordinate(2, 3));
            chess3.Display(new Coordinate(4, 5));

            Console.ReadKey();
        }
    }
}
