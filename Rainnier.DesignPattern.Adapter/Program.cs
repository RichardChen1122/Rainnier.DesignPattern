using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Rainnier.DesignPattern.Adapter.Adaptee;
using Rainnier.DesignPattern.Adapter.Adapter;

namespace Rainnier.DesignPattern.Adapter
{
    //Test git commit in local richard branch
    //test git commit in master branch
    //test git commit in hotfix branch

    //Add some feature in richard branch

    //Do some hotfix
    class Program
    {
        static void Main(string[] args)
        {
            var dbA = new DB("A");
            dbA.DatabaseRead();
            dbA.DatabaseGet();
            dbA.DatabaseWrite();

            var dbB = new DB("B");
            dbB.DatabaseRead();
            dbB.DatabaseGet();
            dbB.DatabaseWrite();

            Console.ReadKey();
        }
    }

    public class DB:IOperateDatabaseB
    {
        IOperateDatabaseB instance;

        public DB(string dbName)
        {
            if(dbName == "A")
            {
                var dbA = new DatabaseOperation();
                instance = new DatabaseAdapter(dbA);
            }
            if (dbName == "B")
            {
                instance = new OperateDatabase();
            }
        }

        public string DatabaseGet()
        {
            return instance.DatabaseGet();
        }

        public void DatabaseRead()
        {
            instance.DatabaseRead();
        }

        public void DatabaseWrite()
        {
            instance.DatabaseWrite();
        }
    }
}
