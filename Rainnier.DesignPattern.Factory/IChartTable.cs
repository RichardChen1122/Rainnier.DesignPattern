using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory
{
    public interface IChartTable
    {
        void Display();

    }

    public enum ChartType
    {
        PieChart =0,
        LineChart =1,
        BarChart =2
    }
}
