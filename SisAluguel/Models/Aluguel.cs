using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Models
{
    public class Aluguel
    {
        public Guid Id { get; set; }

        [Required]
        public Guid ClienteId { get; set; }

        public Cliente Cliente { get; set; }

        public IList<Livro> Livros { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDeEmprestimo { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDeDevolucao { get; set; }
    }
}
