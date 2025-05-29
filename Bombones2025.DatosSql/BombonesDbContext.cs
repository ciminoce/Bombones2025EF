using Bombones2025.Entidades.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Bombones2025.DatosSql
{
    public class BombonesDbContext : DbContext
    {
        public BombonesDbContext(DbContextOptions options) : base(options)
        {
        }

        protected BombonesDbContext()
        {
        }
        public DbSet<Pais> Paises { get; set; }
        public DbSet<Chocolate> Chocolates { get; set; }
        public DbSet<Relleno> Rellenos{ get; set; }
        public DbSet<FrutoSeco> FrutosSecos { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

    }
}
