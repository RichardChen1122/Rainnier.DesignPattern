using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Adapter.Adaptee
{
    public class OperateDatabase
    {
        public void DatabaseRead()
        {
            Console.WriteLine("SystemB read database");
        }

        public void DatabaseWrite()
        {
            Console.WriteLine("SystemB write database");
        }

        public string DatabaseGet()
        {
            Console.WriteLine("SystemB get database");
            return "SystemB get database";
        }
    }
}
