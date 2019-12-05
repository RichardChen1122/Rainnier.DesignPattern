using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous.APMDemo
{
    public class ServerStart
    {
        static void Main(string[] args)
        {
            for (int i = 0; i < Environment.ProcessorCount; i++)
            {
                new PipeServer();
            }

            Console.WriteLine("Press <Enter> to terminate this server application");
            Console.ReadLine();
        }
    }
}
