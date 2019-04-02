using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Adapter.Adapter
{
    public class DatabaseAdapter : IDatabaseAdapter
    {
        public DatabaseAdapter()
        {
        }

        public string Get()
        {
            throw new NotImplementedException();
        }

        public void Read()
        {
            throw new NotImplementedException();
        }

        public void Write()
        {
            throw new NotImplementedException();
        }
    }
}
