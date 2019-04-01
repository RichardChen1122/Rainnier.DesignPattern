using Rainnier.DesignPattern.Builder.Structural;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();

            Rainnier.DesignPattern.Builder.Structural.Builder b1 = new ConcreteBuilder1();
            Rainnier.DesignPattern.Builder.Structural.Builder b2 = new ConcreteBuilder2();

            // Construct two products
            Product p1 = director.Construct(b1);
            p1.Show();

            Product p2 = director.Construct(b2);
            p2.Show();
        }
    }
}
