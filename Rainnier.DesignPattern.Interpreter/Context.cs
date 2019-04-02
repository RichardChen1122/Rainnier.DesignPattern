using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Interpreter
{
    public class Context
    {

        private Dictionary<char, double> variable;

        public Dictionary<char, double> Variable
        {
            get
            {
                if (variable == null)
                {
                    variable = new Dictionary<char, double>();

                }
                return variable;
            }
        }

    }
}
