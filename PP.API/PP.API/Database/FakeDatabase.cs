using PP.API.EC;
using PP.Library.Models;

namespace PP.API.Database
{
    public static class FakeDatabase
    {
        public static List<Client> Clients = new List<Client>
            {
                new Client{ Id = 1, Name = "Client 1"},
                new Client{ Id = 2, Name = "Client 2"},
                new Client{ Id = 3, Name = "Client 3"},
                new Client{ Id = 4, Name = "Client 4"},
                new Client{ Id = 5, Name = "Client 5"},
                new Client{ Id = 6, Name = "Client 6"}
        };

        public static int LastClientId 
            =>  Clients.Any()? Clients.Select(c => c.Id).Max() : 0;
    }
}
