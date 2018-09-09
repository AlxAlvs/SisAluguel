using Microsoft.AspNetCore.Mvc;
using SisAluguel.Context;
using SisAluguel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SisAluguel.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : Controller
    {
        private readonly SisAluguelContexto _sisAluguelContexto;

        public LivroController(SisAluguelContexto sisAluguelContexto)
        {
            _sisAluguelContexto = sisAluguelContexto;
        }

        [HttpGet]
        public IEnumerable<Livro> GetAll()
        {
            return _sisAluguelContexto.Livros.ToList();
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Livro livro)
        {
            livro.Id = _sisAluguelContexto.Livros.ToList().Count + 1;
            livro.SituacaoAluguel = SituacaoAluguel.Disponível;

            _sisAluguelContexto.Livros.Add(livro);
            _sisAluguelContexto.SaveChanges();

            TempData["msg"] = "<script>alert('Cadastrado com sucesso ');</script>";

            return View("livros");
        }

        [HttpDelete]
        public IActionResult Delete(int Id)
        {
            var livro = _sisAluguelContexto.Livros.FirstOrDefault(i => i.Id==Id);
            if (livro != null)
            {
                _sisAluguelContexto.Livros.Remove(livro);
                _sisAluguelContexto.SaveChanges();
                TempData["msg"] = "<script>alert('Removido com sucesso ');</script>";
                return Ok();
            }

            return NoContent();
        }
    }
}
