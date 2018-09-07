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
        public IActionResult GetAll()
        {
            return Ok(_sisAluguelContexto.Livros.ToList());
        }

        [HttpPost]
        public IActionResult Post([FromBody] Livro livro)
        {
            livro.Id = Guid.NewGuid();
            livro.SituacaoAluguel = SituacaoAluguel.Disponível;

            _sisAluguelContexto.Livros.Add(livro);

            _sisAluguelContexto.SaveChanges();

            return Ok(_sisAluguelContexto.Livros.ToList());
        }
    }
}
