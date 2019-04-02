using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Adapter.Adaptee
{
    public class DatabaseOperation :  IDatabaseOperationA
    {
        public void ReadDatabase()
        {
            Console.WriteLine("SystemA read database");
        }

        public void WriteDatabase()
        {
            Console.WriteLine("SystemA write database");
        }

        public string GetDatabase()
        {
            Console.WriteLine("SystemA get database");
            return "SystemA get database";
        }
    }
}
