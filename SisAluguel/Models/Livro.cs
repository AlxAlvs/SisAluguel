using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Models
{
    public class Livro
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "Pecisa conter o minimo de 1 caractere e o máximo de 100.")]
        public string Nome { get; set; }

        [Required]
        public SituacaoAluguel SituacaoAluguel { get; set; }

        public Guid? AluguelId { get; set; }

        public virtual Aluguel Aluguel { get; set; }
    }
}
