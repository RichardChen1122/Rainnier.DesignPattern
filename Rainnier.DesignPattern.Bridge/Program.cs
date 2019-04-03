using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var businessObject = new CustomersBusinessObject("Shanghai");
            businessObject.DataAccess = new DBAccess();

            businessObject.Add("test");

        }
    }
}
