using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using AbaixoAsFakesApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
        [AllowAnonymous]
        [Route("login")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
        {
            // Recupera o usuário
            var user = await _context.Usuarios.Where(x => x.Nome.ToLower() == model.Nome.ToLower() && x.Senha == CriarPasswordHash(model.Senha)).FirstOrDefaultAsync();

            // Verifica se o usuário existe
            if (user == null)
                throw new ArgumentNullException("Usuário ou senha inválidos");

            // Gera o Token
            var token = TokenService.GenerateToken(user, _configuration);

            // Retorna os dados
            return token;
        }

        private string CriarPasswordHash(string senha)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                senha = BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }

            return senha;
        }

        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentNullException("Usuário inválido");

                if (await _context.Usuarios.AnyAsync(x => x.Nome.ToLower() == usuario.Nome.ToLower()))
                    throw new Exception("Nome de usuário já existe.");

                usuario.Senha = CriarPasswordHash(usuario.Senha);

                await _context.Usuarios.AddAsync(usuario);
                await _context.SaveChangesAsync();

                return Ok(usuario.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
    }
}
