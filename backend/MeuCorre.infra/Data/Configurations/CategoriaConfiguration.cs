using MeuCorre.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuCorre.infra.Data.Configurations
{

    class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Usuarios");
            builder.HasKey(categoria => categoria.Id);
            builder.Property(categoria => categoria.Nome).IsRequired().HasMaxLength(100);
            builder.Property(categoria => categoria.Ativo).IsRequired();
            builder.Property(categoria => categoria.DataCriacao).IsRequired();
            builder.Property(categoria => categoria.DataAtualizacao).IsRequired(false);
            builder.Property(categoria => categoria.Icone).IsRequired();
            builder.Property(categoria => categoria.Descricao).IsRequired();
            builder.Property(categoria => categoria.TipoTransacao).IsRequired();
            builder.Property(categoria => categoria.Cor).IsRequired();

            builder.HasOne(categoria => categoria.Usuario)
                .WithMany(usuario => usuario.Categorias)
                .HasForeignKey(categoria => categoria.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
