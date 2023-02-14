using System.Net;
namespace _01_EsempioDNS
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var domainEntry = Dns.GetHostEntry("www.istitutogreppi.edu.it");
            Console.WriteLine(domainEntry.HostName);
            foreach (var ip in domainEntry.AddressList)
            {
                Console.WriteLine(ip);
            }
            var domainEntryByAddress = Dns.GetHostEntry("127.0.0.1");
            Console.WriteLine(domainEntryByAddress.HostName);
            foreach (var ip in domainEntryByAddress.AddressList)
            {
                Console.WriteLine(ip);
            }
        }
    }
}

        