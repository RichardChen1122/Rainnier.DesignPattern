using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.FlyWeight
{
    public class BlackChess : Chess
    {

        public override string GetColor() => "White";
    }

    public class WhiteChess : Chess
    {


        public override string GetColor() => "Black";
    }
}
