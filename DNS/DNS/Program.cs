using System;
using System.Net;
using System.Net.Sockets;

namespace DNS
{
    internal static class Program
    {
        static void Main(string[] args)
        {
            var host = args.Length == 0 ? Dns.GetHostName() : args[0];

            Console.WriteLine($"Host: {host}\n");

            var hostEntry = Dns.GetHostEntry(host);

            foreach (var curAdd in hostEntry.AddressList)
            {
                // Display the type of address family supported by the server. 
                Console.WriteLine("AddressFamily: " + curAdd.AddressFamily.ToString());

                // Display the ScopeId property in case of IPV6 addresses.
                if (curAdd.AddressFamily.ToString() == ProtocolFamily.InterNetworkV6.ToString())
                    Console.WriteLine("Scope Id: " + curAdd.ScopeId.ToString());

                // Display the server IP address in the standard format. 
                Console.WriteLine("Address: " + curAdd.ToString());

                Console.WriteLine("\r\n");
            }

        }

    }
}
