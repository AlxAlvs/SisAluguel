using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SisAluguel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Context.Maps
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("db_cliente", "dbo");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("cd_cliente");

            builder.Property(x => x.Nome).HasColumnName("nm_cliente");

            builder.Property(x => x.Telefone).HasColumnName("tf_cliente");
        }
    }
}
