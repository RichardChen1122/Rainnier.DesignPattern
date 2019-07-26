using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Net.WebSockets;
using System.Net.Sockets;

namespace Rainnier.DesignPattern.Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.IP);
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8080));
            serverSocket.Listen(128);
            serverSocket.BeginAccept(null, 0, OnAccept, null);

            void OnAccept(IAsyncResult result)
            {
                try
                {
                    Socket client = null;
                    if (serverSocket != null && serverSocket.IsBound)
                    {
                        client = serverSocket.EndAccept(result);
                    }
                    if (client != null)
                    {
                        /* Handshaking and managing ClientSocket */
                    }
                }
                catch (SocketException exception)
                {

                }
                finally
                {
                    if (serverSocket != null && serverSocket.IsBound)
                    {
                        serverSocket.BeginAccept(null, 0, OnAccept, null);
                    }
                }
            }
        }


    }
}
