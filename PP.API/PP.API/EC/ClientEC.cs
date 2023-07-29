using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PP.API.Database;
using PP.Library.DTO;
using PP.Library.Models;

namespace PP.API.EC
{
    public class ClientEC
    {
        private EfContext ef = new EfContextFactory().CreateDbContext(new string[0]);
        public ClientDTO AddOrUpdate(ClientDTO dto)
        {
            var client = new Client(dto);
            if (dto.Id <= 0)
            {                             
                ef.Clients.Add(client);
                ef.SaveChanges(); 
            }

            return new ClientDTO(client);
        }

        public ClientDTO? Get(int id)
        {
           var returnVal = FakeDatabase.Clients
                .FirstOrDefault(c => c.Id == id)
                ?? new Client();

            return new ClientDTO(returnVal);
        }

        public ClientDTO? Delete(int id)
        {
            var clientToDelete = FakeDatabase.Clients.FirstOrDefault(c => c.Id == id);
            if (clientToDelete != null)
            {
                FakeDatabase.Clients.Remove(clientToDelete);
            }
            return clientToDelete != null ? 
                new ClientDTO(clientToDelete)
                : null;
        }

        public IEnumerable<ClientDTO> Search(string query = "")
        {
            return ef.Clients.Where(c => c.Name.ToUpper()
                    .Contains(query.ToUpper()))
                .Take(1000)
                .Select(c => new ClientDTO(c));
        }
    }
}
