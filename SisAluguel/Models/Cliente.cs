using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Telefone { get; set; }
    }
}
