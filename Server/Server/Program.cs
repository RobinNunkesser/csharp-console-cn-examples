using System;
using System.Threading;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using static System.Console;

namespace Server
{
    internal static class Program
    {
        private static TcpListener _listener;
        private const int Limit = 5; //5 concurrent clients

        private static readonly Dictionary<string, string> Employees =
            new Dictionary<string, string>
            {
                {"jane", "manager"},
                {"jim", "clerk"},
                {"jack", "salesman"},
                {"john", "steno"}
            };

        public static void Main()
        {
            var localAddr = IPAddress.Parse("127.0.0.1");
            const int port = 2055;
            _listener = new TcpListener(localAddr, port);
            _listener.Start();
            WriteLine($"Server mounted, listening to port {port}");
            for (var i = 0; i < Limit; i++)
            {
                var t = new Thread(new ThreadStart(Service));
                t.Start();
            }
        }

        private static void Service()
        {
            while (true)
            {
                var soc = _listener.AcceptSocket();
                WriteLine("Connected: {0}", soc.RemoteEndPoint);
                try
                {
                    Stream s = new NetworkStream(soc);
                    var sr = new StreamReader(s);
                    var sw = new StreamWriter(s) {AutoFlush = true};
                    sw.WriteLine("{0} Employees available", Employees.Count);
                    while (true)
                    {
                        var name = sr.ReadLine();
                        if (string.IsNullOrEmpty(name)) break;
                        var job = Employees[name] ?? "No such employee";
                        sw.WriteLine(job);
                    }

                    s.Close();
                }
                catch (Exception e)
                {
                    WriteLine(e.Message);
                }

                WriteLine("Disconnected: {0}", soc.RemoteEndPoint);
                soc.Close();
            }
        }
    }
}