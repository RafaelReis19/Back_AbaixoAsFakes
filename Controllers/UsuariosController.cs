using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using AbaixoAsFakesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        IConfiguration _configuration;
        DataContext _context;

        public UsuariosController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            // Recupera o usuário
            var user = new Usuario { Id = 1, Senha = "123456", Role = "A", Nome = "Teste"};

            // Verifica se o usuário existe
            if (user == null)
                throw new ArgumentNullException("Usuário ou senha inválidos");

            // Gera o Token
            var token = TokenService.GenerateToken(user, _configuration);

            // Retorna os dados
            return token;
        }

        [HttpGet]
        [Authorize]
        [Route("Teste")]
        public IActionResult Teste()
        {
            var a =_context.Usuario.ToList();
            var claim = User.FindFirst("teste").Value;
            return Ok(claim);
        }
    }
}
