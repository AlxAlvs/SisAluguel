using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisAluguel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Context.Maps
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {
            builder.ToTable("db_livro", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cd_livro");

            builder.Property(x => x.Nome).HasColumnName("nm_livro");

            builder.Property(x => x.SituacaoAluguel).HasColumnName("st_livro");
        }
    }
}
