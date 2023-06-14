using PP.Library.Models;

namespace PP.Library.Services
{
    public class ClientService
    {
        public List<Client> Clients { 
            get {
                return clients;
            } 
        }

        private List<Client> clients;

        private static ClientService? instance;

        public static ClientService Current
        {
            get
            {
                if (instance == null)
                {
                    instance = new ClientService();
                }
                return instance;
            }
        }
        private ClientService()
        {
            clients = new List<Client>
            {
                new Client{ Id = 1, Name = "Client 1"},
                new Client{ Id = 2, Name = "Client 2"},
                new Client{ Id = 3, Name = "Client 3"},
                new Client{ Id = 4, Name = "Client 4"},
                new Client{ Id = 5, Name = "Client 5"},
                new Client{ Id = 6, Name = "Client 6"}
            };
        }
    }
}
