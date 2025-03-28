using Microsoft.EntityFrameworkCore;
using ProjetoSTI3.Models;

namespace ProjetoSTI3.Data
{
    public class Context : DbContext
    {
        public Context() { }
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Categoria> Categoria { get; set; }

        public DbSet<Cliente> Cliente { get; set; }

        public DbSet<Pedido> Pedido { get; set; }

        public DbSet<PedidoItem> PedidoItem { get; set; }

        public DbSet<Produto> Produto { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
