using ArandaPrueba.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ArandaPrueba.Infraestructure.Configurations
{
    public class TbCategoriaConfig : IEntityTypeConfiguration<TbCategoria>
    {
        public void Configure(EntityTypeBuilder<TbCategoria> entity)
        {
            entity.HasKey(x => x.IdCategoria)
                .HasName("PK_Tb_Categoria");

            entity.ToTable("Tb_Categoria");

            entity.Property(x => x.IdCategoria)
                .HasColumnName("IdCategoria")
                .ValueGeneratedOnAdd()
                .HasColumnType("NUMERIC(18,0)");

            entity.Property(x => x.Descripcion)
                .HasColumnName("Descripcion")
                .HasMaxLength(50);
        }
    }
}