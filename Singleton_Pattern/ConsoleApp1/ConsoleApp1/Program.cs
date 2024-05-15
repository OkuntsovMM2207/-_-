using System;
using System.Collections.Generic;
using System.Linq;

namespace LazySingletonServers
{
    public class Servers
    {
        private static readonly Lazy<Servers> LazyInstance = new Lazy<Servers>(() => new Servers());

        public static Servers Instance => LazyInstance.Value;

        private readonly List<string> _servers = new List<string>();

        private Servers()
        {
        }

        public bool AddServer(string server)
        {
            if (!server.StartsWith("http") && !server.StartsWith("https"))
                return false;

            if (_servers.Contains(server))
                return false;

            _servers.Add(server);
            return true;
        }

        public IEnumerable<string> GetHttpServers()
        {
            return _servers.Where(s => s.StartsWith("http"));
        }

        public IEnumerable<string> GetHttpsServers()
        {
            return _servers.Where(s => s.StartsWith("https"));
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var servers = Servers.Instance;

            servers.AddServer("https://example.com");
            servers.AddServer("http://example.org");
            servers.AddServer("http://example.net");
            servers.AddServer("https://example.com"); // Duplicate, not added

            foreach (var server in servers.GetHttpServers())
            {
                Console.WriteLine($"HTTP: {server}");
            }

            foreach (var server in servers.GetHttpsServers())
            {
                Console.WriteLine($"HTTPS: {server}");
            }
        }
    }
}