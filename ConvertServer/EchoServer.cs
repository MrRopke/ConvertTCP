using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using ConvertComponent;

namespace ConvertServer
{
    internal class EchoServer
    {
        private int pORT;

        ConvertCompo cc = new ConvertCompo();

        public EchoServer(int pORT)
        {
            this.pORT = pORT;
        }

        internal void Start()
        {
            TcpListener serverListener = new TcpListener(IPAddress.Loopback, pORT);
            serverListener.Start();

            while (true)
            {
                TcpClient socket = serverListener.AcceptTcpClient();

                Task.Run(() =>
                {
                    DoClient(socket);
                });
            }
        }

        public void DoClient(TcpClient socket)
        {
            using (StreamReader sr = new StreamReader(socket.GetStream()))
            using (StreamWriter sw = new StreamWriter(socket.GetStream()))
            {
                if (socket.Connected)
                {
                    Console.WriteLine("Client Connected ..");
                }

                string str = sr.ReadLine();
                Console.WriteLine("Client request: " + str);
                string[] strs = str.Split(" ");

                string metode = strs[0];
                string værdi = strs[1];

                double tal = double.Parse(værdi);

                if (metode == "ToGram")
                {
                    sw.WriteLine($"{tal} Ounces = {cc.OuncesToGram(tal)} Gram.");
                    Console.WriteLine($"{tal} Ounces = {cc.OuncesToGram(tal)} Gram.");
                }
                else if (metode == "ToOunces")
                {
                    sw.WriteLine($"{tal} Gram = {cc.GramToOunces(tal)} Ounces.");
                    Console.WriteLine($"{tal} Gram = {cc.GramToOunces(tal)} Ounces.");
                }
                else
                {
                    sw.WriteLine("Wrong Command! /nWrite: Method Amount n/ex. ToGram 100 or ToOunces 100");
                    Console.WriteLine("Wrong Command! / nWrite: Method Amount n/ ex.ToGram 100 or ToOunces 100");
                }

               // sw.WriteLine(str);
                sw.Flush();
            }
        }
    }
}