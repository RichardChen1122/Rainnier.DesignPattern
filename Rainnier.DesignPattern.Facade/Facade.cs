using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Facade
{
    public class EncrptyFacade : AbstractEncrptyFacade
    {
        private FileReader reader;
        private CipherMachine cm;
        private FileWrite writer;

        public EncrptyFacade()
        {
            this.reader = new FileReader();
            this.cm = new CipherMachine();
            this.writer = new FileWrite();
        }

        public override void Encrypt(string src, string des)
        {
            var text = reader.ReadFile(src);
            var e = cm.Encrypt(text);
            writer.WriteFile(des);
        }
    }
}
