using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Decorator
{
    public abstract class ComponentDecorator:Component
    {
        protected List<DecoratorThing> list = new List<DecoratorThing>();
        public void AddDecorator(DecoratorThing item)
        {
            list.Add(item);
        }
    }


    public class ScrollBar : DecoratorThing
    {
        public override void Display()
        {
            Console.WriteLine("Display Scroll Bar");
        }
    }
}
