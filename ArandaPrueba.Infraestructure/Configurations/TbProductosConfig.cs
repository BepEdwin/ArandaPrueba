using ArandaPrueba.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaPrueba.Infraestructure.Configurations
{
    public class TbProductosConfig : IEntityTypeConfiguration<TbProductos>
    {
        public void Configure(EntityTypeBuilder<TbProductos> entity)
        {
            entity.HasKey(x => x.IdProducto)
                .HasName("PK_Tb_Productos");

            entity.ToTable("Tb_Productos");

            entity.Property(x => x.IdProducto)
                .HasColumnName("IdProducto")
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMERIC(18,0)");

            entity.Property(x => x.Nombre)
                .HasColumnName("Nombre")
                .HasMaxLength(50);

            entity.Property(x => x.DescripcionBreve)
                .HasColumnName("Descripcion_breve")
                .HasMaxLength(50);

            entity.Property(x => x.IdCategoria)
                .HasColumnName("IdCategoria")
                .HasColumnType("NUMERIC(18,0)");

            entity.Property(x => x.ImagenProducto)
                .HasColumnName("ImagenProducto")
                .HasColumnType("IMAGE");
        }
    }
}