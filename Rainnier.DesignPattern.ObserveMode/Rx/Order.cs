using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ObserveMode.Rx
{
    internal class Order
    {
        private Guid id;

        public Guid Id { get => id; set => id = value; }
    }
}
