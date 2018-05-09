using System;
using System.Net.Sockets;
using System.Net;

namespace Lab5
{
    class Program
    {
        public static Socket GetSocket(string server, int port){
            Socket s = null;

            IPHostEntry hostEntry = null;
            hostEntry = Dns.GetHostEntry(server);

            foreach (var address in hostEntry.AddressList)
            {
                var ipEndPoint = new IPEndPoint(address, port);
                Socket socket = new Socket(ipEndPoint.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                socket.Connect(ipEndPoint);

                if (socket.Connected){
                    s = socket;
                    break;
                }else{
                    continue;
                }
            }

            return s;
        }
        public static void Main(string[] args)
        {
            new Lab5Client().Start();
        }
    }
}
