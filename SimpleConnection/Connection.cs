using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SimpleConnection
{
    public class Connection
    {
        protected IPEndPoint endpoint;
        protected Socket socket;
        public Connection(string ip, int port)
        {
            endpoint = new IPEndPoint(IPAddress.Parse(ip), port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public static void Receive(Socket socket, Action<string> onReceive)
        {
            try
            {
                byte[] response = new byte[1024];
                while (true)
                {
                    int receivedBytes = socket.Receive(response);
                    onReceive(Encoding.ASCII.GetString(response, 0, receivedBytes));
                }

            }
            catch (SocketException)
            {

            }
        }

        public static void Send(Socket socket, string message)
        {
            if (socket.Connected)
            {
                byte[] data = Encoding.ASCII.GetBytes(message);
                socket.Send(data);
            }
        }
    }
}
