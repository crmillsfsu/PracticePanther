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
        public Client? Client { get; set; }
        public string? Name { get; set; }

        public ProjectDTO(Project p)
        {
            Id = p.Id;
            ClientId = p.ClientId;
            Client = p.Client;
            Name = p.Name;
        }
    }
}
