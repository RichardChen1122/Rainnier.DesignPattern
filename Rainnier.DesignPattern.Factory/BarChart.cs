using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory
{
    public class BarChart : IChartTable
    {
        public BarChart()
        {
            Console.WriteLine("Create bar chart...");
        }

        public void Display()
        {
            Console.WriteLine("Display bar chart...");
        }
    }
}
