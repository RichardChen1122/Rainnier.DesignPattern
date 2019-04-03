using System;

namespace Rainnier.DesignPattern.FlyWeight
{
    public abstract class Chess
    {
        public abstract string GetColor();
        public void Display(Coordinate cord)
        {
            Console.WriteLine($"Place {GetColor()} chess on X:{cord.X}, Y:{cord.Y}");
        }
    }
}