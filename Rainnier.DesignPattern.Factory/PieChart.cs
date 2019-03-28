using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory
{
    public class PieChart : IChartTable
    {
        public PieChart()
        {
            Console.WriteLine("Create Pie Chart...");
        }

        public void Display()
        {
            Console.WriteLine("Display Pie Chart...");
        }
    }
}
