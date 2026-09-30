using Microsoft.EntityFrameworkCore;
using TIENDA_WEB1.models;

namespace TIENDA_WEB1.Data
{
    public class TiendaContext : DbContext
    {
        public TiendaContext(DbContextOptions<TiendaContext> options)
            : base(options)
        {
        }

        public DbSet<Producto> Productos { get; set; } = default!;
    }
}