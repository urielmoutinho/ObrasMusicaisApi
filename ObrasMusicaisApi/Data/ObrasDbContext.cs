using Microsoft.EntityFrameworkCore;
using ObrasMusicaisApi.Models;

namespace ObrasMusicaisApi.Data
{
    public class ObrasDbContext : DbContext
    {
        public ObrasDbContext(DbContextOptions<ObrasDbContext> options) : base(options)
        { }
        public DbSet<ObraModel> Obras { get; set; }
        public DbSet<TitularModel> Titulares { get; set; }
    }
}
