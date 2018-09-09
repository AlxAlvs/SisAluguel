using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SisAluguel.Context;
using SisAluguel.Models;

namespace SisAluguel.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : Controller
    {
        private readonly SisAluguelContexto _SisAluguelContexto;

        public ClienteController(SisAluguelContexto SisAluguelContexto)
        {
            _SisAluguelContexto = SisAluguelContexto;
        }

        public IActionResult Cliente()
        {
            return View("../Cliente/ClienteCadastrar");
        }

        [HttpPost]
        public IActionResult Cadastrar([FromForm]Cliente cliente)
        {
            cliente.Id = Guid.NewGuid();

            _SisAluguelContexto.Clientes.Add(cliente);
            _SisAluguelContexto.SaveChanges();

            TempData["msg"] = "<script>alert('Cadastrado com sucesso ');</script>";

            return View("../Livro/livros");
        }
    }
}