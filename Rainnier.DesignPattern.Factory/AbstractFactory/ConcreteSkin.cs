using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.AbstractFactory
{
    public class SpringButton : Button
    {
        public override void Display()
        {
            Console.WriteLine("显示春天的Button");
        }
    }

    public class SpringComboBox : ComboBox
    {
        public override void Display()
        {
            Console.WriteLine("显示春天的ComboBox");
        }
    }

    public class SpringTextField : TextField
    {
        public override void Display()
        {
            Console.WriteLine("显示春天的TextField");
        }
    }

    public class SummerButton : Button
    {
        public override void Display()
        {
            Console.WriteLine("显示夏天的Button");
        }
    }

    public class SummerComboBox : ComboBox
    {
        public override void Display()
        {
            Console.WriteLine("显示夏天的ComboBox");
        }
    }

    public class SummerTextField : TextField
    {
        public override void Display()
        {
            Console.WriteLine("显示夏天的TextField");
        }
    }
}
