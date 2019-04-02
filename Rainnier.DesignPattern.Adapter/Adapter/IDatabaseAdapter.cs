using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Adapter.Adapter
{
    public interface IDatabaseAdapter
    {
        void Read();
        void Write();
        string Get();
    }
}
