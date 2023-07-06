using Newtonsoft.Json;
using PP.Library.Models;
using PP.Library.Utilities;

namespace PP.Library.Services
{
    public class ClientService
    {
        private List<Client> clients;
        public List<Client> Clients { 
            get {
                
                return clients ?? new List<Client>();
            } 
        }

        //private List<Client> clients;

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
            var response = new WebRequestHandler()
                    .Get("/Client")
                    .Result;

            clients = JsonConvert
                .DeserializeObject<List<Client>>(response)
                ?? new List<Client>();
            
        
        }

        public void Delete(int id)
        {
            var clientToDelete = Clients.FirstOrDefault(c => c.Id == id);
            if(clientToDelete != null)
            {
                Clients.Remove(clientToDelete);
            }
        }

        public void AddOrUpdate(Client c)
        {
            var response 
                = new WebRequestHandler().Post("/Client", c).Result;
            //MISSING CODE
            var myUpdatedClient = JsonConvert.DeserializeObject<Client>(response);
            if(myUpdatedClient != null)
            {
                var existingClient = clients.FirstOrDefault(c => c.Id == myUpdatedClient.Id);
                if(existingClient == null)
                {
                    clients.Add(myUpdatedClient);
                }else
                {
                    var index = clients.IndexOf(existingClient);
                    clients.RemoveAt(index);
                    clients.Insert(index, myUpdatedClient);
                }
            }

        }

        public Client? Get(int id)
        {
            /*var response = new WebRequestHandler()
                    .Get($"/Client/GetClients/{id}")
                    .Result;
            var client = JsonConvert.DeserializeObject<Client>(response);*/
            return Clients.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Client> Search(string query)
        {
            return Clients
                .Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()));
        }

        private int LastId
        {
            get
            {
                return Clients.Any() ? Clients.Select(c => c.Id).Max() : 0;
            }
        }
    }
}
