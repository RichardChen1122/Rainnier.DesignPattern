using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AttributeDemo
{
    [AttributeUsage(AttributeTargets.Property)]
    public abstract class ValidatorAttribute:Attribute
    {
        public abstract bool IsValid(string obj);

    }
    [AttributeUsage(AttributeTargets.Property)]
    public class EmailAttribute: ValidatorAttribute
    {
        public override bool IsValid(string obj)
        {
            var result = false;

            if (obj.Contains(@"@"))
            {
                return true;
            }
            return result;

        }

        public override bool Match(object obj)
        {
            return base.Match(obj);
        }
    }

    [AttributeUsage(AttributeTargets.Property)]
    public class SomeOtherAttribute : Attribute
    {

    }

    public class Model
    {
        [Email]
        public string Mail { get; set; }
        [SomeOther]
        public int Other { get; set; }
    }
}
