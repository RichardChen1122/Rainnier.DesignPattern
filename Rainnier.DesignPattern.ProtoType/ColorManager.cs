using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ProtoType
{
    public class ColorManager
    {
        private Dictionary<string, Color> dic => new Dictionary<string, Color>();

        public Color this[string colorName]
        {
            get
            {
                return dic[colorName];
            }
            set
            {
                dic.Add(colorName, value);
            }
        }
    }
}
