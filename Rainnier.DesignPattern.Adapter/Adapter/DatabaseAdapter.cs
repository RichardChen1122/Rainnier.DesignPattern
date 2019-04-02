using Rainnier.DesignPattern.Adapter.Adaptee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Adapter.Adapter
{
    public class DatabaseAdapter : IOperateDatabaseB
    {
        private IDatabaseOperationA databasea;
        public DatabaseAdapter(IDatabaseOperationA a)
        {
            databasea = a;
        }

        public string DatabaseGet() => databasea.GetDatabase();

        public void DatabaseRead() => databasea.ReadDatabase();

        public void DatabaseWrite() => databasea.WriteDatabase();
        
    }
}
