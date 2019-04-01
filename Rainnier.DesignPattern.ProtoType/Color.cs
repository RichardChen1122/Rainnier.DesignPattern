using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ProtoType
{
    [Serializable]
    public class Color : ColorProtoType
    {
        private int _red;
        private int _green;
        private int _blue;

        /// <summary>
        /// Constructor
        /// </summary>
        public Color(int red, int green, int blue)
        {
            this._red = red;
            this._green = green;
            this._blue = blue;
        }

        /// <summary>
        /// Create a shallow copy
        /// </summary>
        public override object Clone()
        {
            // 浅复制
            //Console.WriteLine("Cloning color RGB: {0,3},{1,3},{2,3}", _red, _green, _blue);
            //return this.MemberwiseClone();

            //  deep copy
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, this);
            ms.Position = 0;
            return bf.Deserialize(ms);
        }
    }
}
