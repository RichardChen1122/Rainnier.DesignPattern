using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.AbstractFactory
{
    public interface IItem
    {
        void Display();
    }

    public abstract class ComboBox : IItem
    {
        public abstract void Display();
    }

    public abstract class Button : IItem
    {
        public abstract void Display();
    }

    public abstract class TextField : IItem
    {
        public abstract void Display();
    }
}
