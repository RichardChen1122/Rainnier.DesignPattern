using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Facade
{
    public class FileReader
    {

        public string ReadFile(string fileName)
        {
            Console.WriteLine($"Read file {fileName}");
            return "Readed File";
        }
    }

    public class FileWrite
    {
        public void WriteFile(string name)
        {
            Console.WriteLine($"Write file {name}");
        }
    }

    public class CipherMachine
    {
        public string Encrypt(string text)
        {
            Console.WriteLine($"Encrypt {text}");

            return "Encrypted file";
        }
    }

}
