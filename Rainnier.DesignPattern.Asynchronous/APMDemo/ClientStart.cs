using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous.APMDemo
{
    public class ClientStart
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < 100; i++)
            {
                new PipeClient("localhost", "Request #" + i);

            }

            Console.ReadLine();
        }
    }
}
