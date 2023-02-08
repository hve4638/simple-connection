using System;
using System.Net.Sockets;
using System.Net;
using System.Text;

namespace SimpleConnection
{
    public class Client : Connection
    {
        public Client(string ip, int port) : base(ip, port)
        {

        }

        public void Connect() => socket.Connect(endpoint);
        public void Receive() => Receive(socket, Console.WriteLine);
        public void Receive(Action<string> onReceive) => Receive(socket, onReceive);
        public void Send(string message) => Send(socket, message);
    }
}
