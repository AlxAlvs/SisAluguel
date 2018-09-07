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

        [RegularExpression("^(?!0+$)(\\+\\d{1,3}[- ]?)?(?!0+$)\\d{10,15}$", ErrorMessage = "Cadastre um numero de telefone válido")]
        public string Telefone { get; set; }
    }
}
