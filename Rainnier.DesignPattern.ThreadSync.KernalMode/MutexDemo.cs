using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.ThreadSync.KernalMode
{
    public class MutexDemo
    {
        //用于Mutex的Test
        static void Main(string[] args)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            string dir = Environment.CurrentDirectory;
            dir = dir.Replace("/", "");
            dir = dir.Replace("\\", "");
            byte[] result = md5.ComputeHash(Encoding.Default.GetBytes(dir));
            string md5Text = Encoding.Default.GetString(result);
            Console.WriteLine("目录层级的Muxtex测试，请点开多个此程序控制台：");
            //增加using防止Muxtex在程序运行时被垃圾回收
            using (Mutex run = new Mutex(true, md5Text, out bool runOne))
            {
                if (!runOne)
                {
                    Console.WriteLine("同一目录已经运行了一个程序实例,无法重复运行");
                    Console.ReadLine();
                    return;  //增加return语句，防止用户回车后继续运行程序；
                }

                try
                {
                    while (true)
                    {
                        //程序执行主体代码
                        Console.Write(".");
                        Thread.Sleep(1000);
                    }
                }
                finally
                {
                    //释放当前Mutex一次
                    run.ReleaseMutex();
                }
            }
        }
    }
}
