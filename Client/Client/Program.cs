using System.IO;
using System.Net.Sockets;
using static System.Console;

namespace Client
{
    internal static class Program
    {
        public static void Main(string[] args)
        {
            const string localAddr = "127.0.0.1";
            const int port = 2055;
            var client = new TcpClient(localAddr, port);
            try
            {
                Stream s = client.GetStream();
                var sr = new StreamReader(s);
                var sw = new StreamWriter(s) {AutoFlush = true};
                WriteLine(sr.ReadLine());
                while (true)
                {
                    Write("Name: ");
                    var name = ReadLine();
                    sw.WriteLine(name);
                    if (name == "") break;
                    WriteLine(sr.ReadLine());
                }
                s.Close();
            }
            finally
            {
                client.Close();
            }
        }
    }
}
