using Microsoft.EntityFrameworkCore;
using SisAluguel.Context.Maps;
using SisAluguel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Context
{
    public class SisAluguelContexto : DbContext
    {
        public SisAluguelContexto(DbContextOptions<SisAluguelContexto> options)
        : base(options)
        {
        }

        public DbSet<Aluguel> Alugueis { get; set; }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Livro> Livros { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AluguelMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new LivroMap());

            base.OnModelCreating(modelBuilder);

        }
    }
}
