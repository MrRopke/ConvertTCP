using System;

namespace ConvertClient
{
    class Program
    {
        private const int PORT = 7;

        static void Main(string[] args)
        {
            EchoClient server = new EchoClient(PORT);
            server.Start();

            Console.ReadLine();
        }
    }
}
