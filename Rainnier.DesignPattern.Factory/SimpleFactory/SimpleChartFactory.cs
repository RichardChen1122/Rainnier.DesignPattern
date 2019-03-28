using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.SimpleFactory
{
    public class SimpleChartFactory
    {
        public static IChartTable GetChart(ChartType chartType)
        {
            IChartTable chart = null;
            switch (chartType)
            {
                case ChartType.PieChart:
                    chart = new PieChart();
                    Console.WriteLine("Init Pie Chart..");
                    break;
                case ChartType.LineChart:
                    chart = new LineChart();
                    Console.WriteLine("Init line Chart..");
                    break;
                case ChartType.BarChart:
                    chart = new BarChart();
                    Console.WriteLine("Init Bar Chart..");
                    break;

            }

            return chart;
        }
    }
}
