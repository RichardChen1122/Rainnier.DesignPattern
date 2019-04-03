using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.FlyWeight
{
    public class FlyweightFactory
    {
        private static FlyweightFactory instance;
        private static Hashtable table;

        private FlyweightFactory()
        {
            table = new Hashtable();
            table.Add("white", new WhiteChess());
            table.Add("black", new BlackChess());
        }

        public static FlyweightFactory GetInstance()
        {
            if (instance == null)
            {
                instance = new FlyweightFactory();
            }

            return instance;
        }

        public Chess GetChess(string color)
        {
            return table[color] as Chess;
        }
    }
}
