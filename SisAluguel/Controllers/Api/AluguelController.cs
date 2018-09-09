using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SisAluguel.Context;
using SisAluguel.Models;

namespace SisAluguel.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AluguelController : Controller
    {
        private readonly SisAluguelContexto _SisAluguelContexto;

        public AluguelController(SisAluguelContexto SisAluguelContexto)
        {
            _SisAluguelContexto = SisAluguelContexto;
        }

        public IActionResult Aluguel()
        {

            ViewBag.Clientes = _SisAluguelContexto.Clientes.ToList().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.Id.ToString() });

            ViewBag.Livros = _SisAluguelContexto.Livros.ToList().Select(c => new SelectListItem()
            { Text = c.Nome, Value = c.Id.ToString() });

            return View("../Aluguel/Aluguel");
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]ViewModelAluguel viewModelAluguel)
        {
            var livro = _SisAluguelContexto.Livros.FirstOrDefault(i => i.Id == viewModelAluguel.IdLivro);

            if (livro != null)
            {
                livro.SituacaoAluguel = SituacaoAluguel.Alugado;
                Guid id = Guid.NewGuid();
                Aluguel aluguel = new Aluguel(id, viewModelAluguel.IdCliente, livro, viewModelAluguel.DataDeEmprestimo, viewModelAluguel.DataDeDevolucao);

                _SisAluguelContexto.Alugueis.Add(aluguel);
                _SisAluguelContexto.SaveChanges();

                TempData["msg"] = "<script>alert('Cadastrado com sucesso ');</script>";
                return View("../Livro/livros", Ok());
            }

            return View("../Livro/livros", NoContent());

        }
    }
}