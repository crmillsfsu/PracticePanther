using PP.Library.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PP.Library.Models
{
    public class Client
    {
        public Client() {
            Name = string.Empty;
            Projects = new List<Project>();
        }
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Project>? Projects { get; set; }

        public Client(ClientDTO dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Projects = dto.Projects;
        }

        public string? Property1 { get; set; }
        public string? Property2 { get; set; }
        public string? Property3 { get; set; }
        public string? Property4 { get; set; }
        public string? Property5 { get; set; }
        public string? Property6 { get; set; }
        public string? Property7 { get; set; }
        public string? Property8 { get; set; }
        public string? Property9 { get; set; }
        public string? Property10 { get; set; }


        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
