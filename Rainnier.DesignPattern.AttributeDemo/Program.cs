using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.AttributeDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //First Attribute Demo
            //CanWriteCheck(new ChildAccount());
            //CanWriteCheck(new AdultAccount());
            var ins = new Model();
            ins.Mail = "rich@123.com";
            ins.Other = 12;
            var boolre = CheckIsValid(ins);
            if (boolre)
            {
                Console.WriteLine($"{ins.Mail} is valid Email address");
            }
            else
            {
                Console.WriteLine($"{ins.Mail} is NOT valid Email address");
            }

            Console.ReadKey();
        }

        static bool CheckIsValid(object obj)
        {
            ValidatorAttribute[] attribute = null;
            var t = obj.GetType();
            var properties = t.GetProperties();
            bool result = true;
            foreach (var p in properties)
            {
                //获取
                attribute = (ValidatorAttribute[])p.GetCustomAttributes(typeof(ValidatorAttribute), true);

                foreach (var a in attribute)
                {

                    var val = p.GetValue(obj);
                    result = a.IsValid((String)val) && result;

                }
            }

            return result;
        }

        static void CanWriteCheck(Object obj)
        {
            Attribute checking = new AccountsAttribute(Accounts.Checking);

            Attribute validAccounts = Attribute.GetCustomAttribute(obj.GetType(), typeof(AccountsAttribute), false);

            if (validAccounts != null && checking.Match(validAccounts))
            {
                Console.WriteLine($"{obj.GetType()} types can write checks.");
            }
            else
            {
                Console.WriteLine($"{obj.GetType()} types can NOT write checks.");
            }
        }

    }
}
