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
            var user = new Usuario { Id = 1, senhaString = "123456", Role = "A", Nome = "Teste"};

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
        /*
         * private void CriarPasswordHash(string senhaString, out byte[] hashSenha, out byte[] sehna)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                sehna = hmac.Key;
                hashSenha = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senhaString));
            } //Método que gera o Hash e o Salt da senha
        }
        public async Task<bool> UsuarioExistente(string apelido)
        {
            if(await _context.Usuarios.AnyAsync(x => x.apelido.ToLower() == apelido.ToLower()))
            {
                return true;
            }
            return false;
        }


        [AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarUsuario(Usuario novoUser)
        {
            try
            {
                if(await UsuarioExistente(novoUser.apelido))
                 throw new System.Exception("Nome de usuário já existe.");

                CriarPasswordHash(novoUser.senhaString, out byte[] hashSenha, out byte[] sehna);
                novoUser.senhaString = string.Empty;
                novoUser.hashSenha = hashSenha;
                novoUser.sehna = sehna;

                await _context.Usuarios.AddAsync(novoUser);
                await _context.SaveChangesAsync(); 

                //return CreatedAtAction(nameof(GetTodoItem) = new { id = user.idUsuario }, user);
                return Ok(novoUser.idUsuario);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }
        private bool VerificarPasswordHash(string senhaString, byte[] hashSenha, byte[] sehna)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(sehna))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senhaString));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != hashSenha[i])
                    {
                        return false;
                    }
                }
                return true;
            }
        } //Método que recebe e valida a senha.

        [AllowAnonymous]
        [HttpPost("Autenticar")]
        public async Task<IActionResult> AutenticarUsuario(Usuario credenciais)
        {
            try
            {
                Usuario? usuario = await _context.Usuarios.FirstOrDefaultAsync(x => x.apelido.ToLower()
                    .Equals(credenciais.apelido.ToLower()));
                //Usuario? usuario = usuarios;
                if (usuario == null)
                {
                    throw new System.Exception("Usuário não encontrado.");
                }


                else if (!VerificarPasswordHash(credenciais.senhaString, usuario.hashSenha, usuario.sehna))
                {
                    throw new System.Exception("Senha incorreta.");
                }
                else if(usuario.senhaString != credenciais.senhaString)
                //{
                  //  throw new System.Exception("Senha incorreta.");
                //}

                else
                {
                    //return Ok(usuario.idUsuario);
                    return Ok(CriarToken(usuario));
                }
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Usuario> lista = await _context.Usuarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
         */
    }
}
