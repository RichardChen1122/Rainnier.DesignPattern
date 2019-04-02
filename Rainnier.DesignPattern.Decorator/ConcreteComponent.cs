using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Decorator
{
    public class Window : ComponentDecorator
    {

        public override void Display()
        {
            Console.WriteLine("Display Window");

            foreach(var a in list)
            {
                a.Display();
            }
        }
    }

    public class TextArea : ComponentDecorator
    {

        public override void Display()
        {
            Console.WriteLine("Display Text Area");
        }
    }

    public class ListBox : ComponentDecorator
    {

        public override void Display()
        {
            Console.WriteLine("Display List Box");
        }
    }
}
