using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory
{
    public class LineChart : IChartTable
    {
        public LineChart()
        {
            Console.WriteLine("Create line Chart...");
        }
        public void Display()
        {
            Console.WriteLine("Display line Chart...");
        }
    }
}
