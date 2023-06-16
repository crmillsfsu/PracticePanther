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
        public int Id { get; set; }
        
        public string Name { get; set; }

        public List<Project> Projects { get; set; }

        public override string ToString()
        {
            return $"{Id} {Name}";
        }
    }
}
