using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Models
{
    public class ViewModelAluguel
    {
        public int IdLivro { get; set; }
        public Guid IdCliente { get; set; }
        public List<Cliente> Clientes { get; set; }
        public List<Livro> Livros { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDeEmprestimo { get; set; }

        [DisplayFormat(DataFormatString = "dd/mm/yyyy")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime DataDeDevolucao { get; set; }

    }
}
