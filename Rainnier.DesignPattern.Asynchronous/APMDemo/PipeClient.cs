using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous.APMDemo
{
    public class PipeClient
    {
        private readonly NamedPipeClientStream m_pipe;

        public PipeClient(string serverName, string message)
        {
            m_pipe = new NamedPipeClientStream(serverName, "Echo", PipeDirection.InOut, PipeOptions.Asynchronous | PipeOptions.WriteThrough);
            m_pipe.Connect();
            m_pipe.ReadMode = PipeTransmissionMode.Message;

            var output = Encoding.UTF8.GetBytes(message);

            m_pipe.BeginWrite(output, 0, output.Length, WriteDone, null);
        }

        private void WriteDone(IAsyncResult ar)
        {
            m_pipe.EndWrite(ar);

            var data = new byte[1000];
            m_pipe.BeginRead(data, 0, data.Length, GotResponse, data);
        }

        private void GotResponse(IAsyncResult ar)
        {
            var bytesRead = m_pipe.EndRead(ar);

            var data = (byte[])ar.AsyncState;

            Console.WriteLine("Server Response:" + Encoding.UTF8.GetString(data, 0, bytesRead));
                 
        }
    }
}
