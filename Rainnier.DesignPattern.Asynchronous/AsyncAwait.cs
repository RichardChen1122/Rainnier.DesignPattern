using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous
{
    class AsyncAwait
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"before call {Thread.CurrentThread.ManagedThreadId}");
            var ret = DoCurlAsync(); //这一行代表不等待，DoCurlAsync 一运行到await 会直接返回
            DoCurlAsync().Wait(); //这一行代表必须等待DoCurlAsync内的await运行完成

            Console.WriteLine("return");

            Console.WriteLine($"after call {Thread.CurrentThread.ManagedThreadId}");

            Console.ReadKey();
        }

        public static async Task<string> DoCurlAsync()
        {
            var httpClient = new HttpClient();
            Console.WriteLine($"before get {Thread.CurrentThread.ManagedThreadId}");

            //ConfigureAwait(false) 的作用 https://blog.csdn.net/WPwalter/article/details/79673214
            var httpResonse = await httpClient.GetAsync("https://www.baidu.com").ConfigureAwait(false);
            Console.WriteLine($"after get {Thread.CurrentThread.ManagedThreadId}");
            return await httpResonse.Content.ReadAsStringAsync();

        }
    }
}
