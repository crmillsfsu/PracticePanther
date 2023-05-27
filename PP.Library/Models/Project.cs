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
    }
}
