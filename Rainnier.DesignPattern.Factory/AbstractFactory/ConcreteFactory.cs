using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.AbstractFactory
{
    public class SpringSkinFactory : SkinFactroy
    {
        public override Button CreateButton()
        {
            return new SpringButton();
        }

        public override ComboBox CreateComboBox()
        {
            return new SpringComboBox();
        }

        public override TextField CreateTextField()
        {
            return new SpringTextField();
        }
    }

    public class SummerSkinFactory : SkinFactroy
    {
        public override Button CreateButton()
        {
            return new SummerButton();
        }

        public override ComboBox CreateComboBox()
        {
            return new SummerComboBox();
        }

        public override TextField CreateTextField()
        {
            return new SummerTextField();
        }
    }
}
