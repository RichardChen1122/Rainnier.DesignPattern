using Rainnier.DesignPattern.Factory.AbstractFactory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory
{
    class Program
    {
        static void Main(string[] args)
        {
            var factory = new SpringSkinFactory();

            var button =factory.CreateButton();
            button.Display();
            Console.ReadKey();
        }
    }
}
