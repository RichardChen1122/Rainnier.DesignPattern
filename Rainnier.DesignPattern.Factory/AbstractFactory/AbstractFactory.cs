using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Factory.AbstractFactory
{
    public abstract class SkinFactroy : ISkinFactory
    {
        public abstract Button CreateButton();
        public abstract ComboBox CreateComboBox();
        public abstract TextField CreateTextField();
    }

    

    public interface ISkinFactory
    {
        Button CreateButton();
        TextField CreateTextField();
        ComboBox CreateComboBox();
    }

   
}
