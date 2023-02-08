using SimpleConnection;

namespace TestClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var client = new Client("127.0.0.1", 6000);
            client.Connect();

            Task.Factory.StartNew(client.Receive);

            string? message;
            while ((message = Console.ReadLine()) != null)
            {
                client.Send(message);
            }
        }
    }
}