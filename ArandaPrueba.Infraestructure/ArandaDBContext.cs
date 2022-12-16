using ArandaPrueba.Core.Entities;
using ArandaPrueba.Infraestructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace ArandaPrueba.Infraestructure
{
    public partial class ArandaDBContext : DbContext
    {
        public ArandaDBContext()
        {
        }

        public ArandaDBContext(DbContextOptions<ArandaDBContext> options) : base(options)
        {
        }

        public virtual DbSet<TbCategoria> TbCategoria { get; set; }
        public virtual DbSet<TbProductos> TbProducto { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TbCategoriaConfig());
            modelBuilder.ApplyConfiguration(new TbProductosConfig());
        }
    }
}