using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.FactoryMethod
{
    public class PieChartFactory : IFactory
    {
        public IChartTable GetChart()
        {
            IChartTable chart = null;
            chart = new PieChart();

            return chart;
        }
    }

    public class LineChartFactory : IFactory
    {
        public IChartTable GetChart()
        {
            IChartTable chart = null;
            chart = new LineChart();

            return chart;
        }
    }

    public class BarChartFactory : IFactory
    {
        public IChartTable GetChart()
        {
            IChartTable chart = null;
            chart = new BarChart();

            return chart;
        }
    }
}
