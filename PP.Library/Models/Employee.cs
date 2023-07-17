using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace PP.Library.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public decimal Rate { get; set; }

        public override string ToString() => Name ?? string.Empty;
    }
}
