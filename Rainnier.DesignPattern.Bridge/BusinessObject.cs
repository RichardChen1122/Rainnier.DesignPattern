using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Bridge
{
    public class BusinessObject
    {
        private DataAccess dataAccess;
        private string city;
        public DataAccess DataAccess
        {
            get { return dataAccess; }
            set { dataAccess = value; }
        }

        public BusinessObject(string city)
        {
            this.city = city;
        }

        public virtual void Add(string name)
        {
            DataAccess.AddRecord(name);
        }

        public virtual void Delete(string name)
        {
            DataAccess.DeleteRecord(name);
        }

        public virtual void Update(string name)
        {
            DataAccess.UpdateRecord(name);
        }

        public virtual string Get(int index)
        {
            return DataAccess.GetRecord(index);
        }
        public virtual void ShowAll()
        {
            Console.WriteLine();
            Console.WriteLine("{0}的顾客有：", city);
            DataAccess.ShowAllRecords();
        }
    }

    public class CustomersBusinessObject : BusinessObject
    {
        public CustomersBusinessObject(string city)
            : base(city) { }

        // 重写方法
        public override void ShowAll()
        {
            Console.WriteLine("------------------------");
            base.ShowAll();
            Console.WriteLine("------------------------");
        }
    }
}
