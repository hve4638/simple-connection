using SimpleConnection;

namespace TestServer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new Server("127.0.0.1", 6000);
            server.Accept();
            Task.Factory.StartNew(server.Receive);

            string? message;
            while((message = Console.ReadLine()) != null)
            {
                server.Send(message);
            }
        }
    }
}