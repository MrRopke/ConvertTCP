using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace ConvertClient
{
    class EchoClient
    {
        private int pORT;

        public EchoClient (int pORT)
        {
            this.pORT = pORT;
        }

        internal void Start()
        {
            using (TcpClient socket = new TcpClient("localhost", pORT))
            using (NetworkStream ns = socket.GetStream())
            using (StreamWriter sw = new StreamWriter(ns))
            using (StreamReader sr = new StreamReader(ns))
            {
                if (socket.Connected)
                {
                    Console.WriteLine("Connected to Host ..");
                    Console.WriteLine("Write: Method Amount n/ex.ToGram 100 or ToOunces 100");
                }

                string request = Console.ReadLine();
                sw.WriteLine(request);
                sw.Flush();

                string response = sr.ReadLine();
                Console.WriteLine(response);

            }
        }
    }
}
