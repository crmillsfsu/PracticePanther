using Microsoft.EntityFrameworkCore;
using PP.Library.Models;

namespace PP.API.Database
{
    public class EfContext : DbContext
    {
        public EfContext(DbContextOptions<EfContext> options)
            : base(options) { }

        public DbSet<Client> Clients { get; set; }
    }
}
