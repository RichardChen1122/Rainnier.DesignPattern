﻿using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rainnier.DesignPattern.Asynchronous.APMDemo
{
    internal sealed class PipeServer
    {
        private readonly NamedPipeServerStream m_pipe = new NamedPipeServerStream("Echo", PipeDirection.InOut, -1, PipeTransmissionMode.Message,
                                                        PipeOptions.Asynchronous | PipeOptions.WriteThrough);

        public PipeServer()
        {
            m_pipe.BeginWaitForConnection(ClientConnected, null);
        }

        private void ClientConnected(IAsyncResult result)
        {
            new PipeServer();
            m_pipe.EndWaitForConnection(result);

            Byte[] data = new byte[1000];

            m_pipe.BeginRead(data, 0, data.Length, GotRequest, data);
        }

        private void GotRequest(IAsyncResult result)
        {
            int bytesRead = m_pipe.EndRead(result);
            var data = (byte[])result.AsyncState;

            data = Encoding.UTF8.GetBytes(Encoding.UTF8.GetString(data, 0, bytesRead).ToUpper().ToCharArray());

            m_pipe.BeginWrite(data, 0, data.Length, WriteDone, null);
        }

        private void WriteDone(IAsyncResult result)
        {
            m_pipe.EndWrite(result);
            m_pipe.Close();
        }
    }
}
