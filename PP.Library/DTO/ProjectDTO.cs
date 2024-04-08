using PP.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.DTO
{
    public class ProjectDTO
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public ClientDTO? Client { get; set; }
        public string? Name { get; set; }
        public ProjectDTO() { }
        public ProjectDTO(Project p)
        {
            Id = p.Id;
            ClientId = p.ClientId;
            Client = new ClientDTO(p?.Client ?? new Client());
            Name = p.Name;
        }
    }
}
