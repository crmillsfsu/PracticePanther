using PP.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.Library.Models
{
    public class Project
    {
        public int Id { get; set; }
        public int ClientId { get; set; }
        public Client? Client {get; set;}
        public string? Name { get; set; }

        public Project() { }

        public Project(ProjectDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.ClientId = dto.ClientId;
            this.Client = new Client(dto?.Client ?? new ClientDTO());
        }

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
