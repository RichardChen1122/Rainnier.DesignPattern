using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Singleton
{
    public class Product
    {
        //private static Product _instance;

        private Product()
        {

        }

        public static Product GetInstance()
        {
            // 第一重判断
            //if (instance == null)
            //{
            //    // 锁定代码块
            //    lock (syncLocker)
            //    {
            //        // 第二重判断
            //        if (instance == null)
            //        {
            //            instance = new LoadBalancer();
            //        }
            //    }
            //}
            //return instance;

            /* 线程不安全 
            if (_instance == null)
            {
                _instance = new Product();
            }

            return _instance;*/
            return LazyHolder.INSTANCE;

        }
        class LazyHolder
        {
            static LazyHolder() { }
            internal static Product INSTANCE = new Product();
        }
    }
}
