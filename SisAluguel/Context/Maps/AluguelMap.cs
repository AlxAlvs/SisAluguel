using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisAluguel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Context.Maps
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("db_aluguel", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cd_aluguel");

            builder.Property(x => x.DataDeDevolucao).HasColumnName("dd_aluguel");

            builder.Property(x => x.DataDeEmprestimo).HasColumnName("de_aluguel");

            builder.Property(x => x.ClienteId).HasColumnName("cd_cliente");

            builder.HasOne(x => x.Cliente).WithMany().HasForeignKey(x => x.ClienteId).IsRequired();

            builder.HasOne(x => x.Livro).WithOne(x => x.Aluguel);
        }
    }
}
