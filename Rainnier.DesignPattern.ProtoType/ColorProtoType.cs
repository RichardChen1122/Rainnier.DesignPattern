using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ProtoType
{
    [Serializable]
    public abstract class ColorProtoType : ICloneable
    {
        public abstract object Clone();
    }
}
