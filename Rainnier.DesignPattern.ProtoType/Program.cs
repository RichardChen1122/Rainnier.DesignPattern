using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ProtoType
{
    class Program
    {
        static void Main(string[] args)
        {
            var manager = new ColorManager();

            manager["red"] = new Color(255, 0, 0);

            var newColor = manager["red"].Clone() as Color;

            Console.ReadKey();
        }
    }
}
