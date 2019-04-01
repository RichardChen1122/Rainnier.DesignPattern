using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Builder.Structural
{
    public class Director
    {
        public Product Construct(Builder builder)
        {
            builder.BuildPartA();
            builder.BuildPartB();

            return builder.GetResult();
        }
    }
}
