using System.Net.Sockets;
using System.Net;
using System.Text;
using System;

namespace SimpleConnection
{
    public class Server : Connection
    {
        Socket client;
        public Server(string ip, int port) : base(ip, port)
        {

        }

        public void Accept()
        {
            socket.Bind(endpoint);
            socket.Listen(10);
            client = socket.Accept();
        }

        public void Receive() => Receive(client, Console.WriteLine);
        public void Receive(Action<string> onReceive) => Receive(client, onReceive);
        public void Send(string message) => Send(client, message);
    }
}
