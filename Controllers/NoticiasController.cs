using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace AbaixoAsFakesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiasController : ControllerBase
    {
        IConfiguration _configuration;
        DataContext _context;

        public NoticiasController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        /*
         * [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Noticia> lista = await _context.Noticias.ToListAsync();
                var b = User.Identity?.Name;
                var a = User.Claims.ToList();
                return Ok(a);
            }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpGet("{idNot}")] //buscar pelo id
        public async Task<IActionResult> GetSingle(int idNot)
        {
            try
            {
                Noticia n = await _context.Noticias //.Include(u => u.idUsuario1)
                    .FirstOrDefaultAsync
                    (nBusca => nBusca.idNoticia == idNot);
                return Ok(n);
        }
            catch (System.Exception ex)
            {
                
                return BadRequest(ex.Message);
            }
        }

        //[AllowAnonymous]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarNoticia(Noticia novaNot)
        {
            try
            {
                //novaNot.idUsuario = _context.Usuarios.Find();
                await _context.Noticias.AddAsync(novaNot);
                await _context.SaveChangesAsync();
                //return CreatedAtAction(nameof(GetTodoItem) = new { id = user.idUsuario }, user);
                return Ok(novaNot.idNoticia);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        private int ObterUsuario()
        {
            return int.Parse(_httpContextAcessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }

        [HttpDelete("{idNot}")]
        public async Task<IActionResult> Delete(int idNot)
        {
            try
            {
                Noticia nRemover = await _context.Noticias.FirstOrDefaultAsync(n => n.idNoticia == idNot);
                _context.Noticias.Remove(nRemover);
                int linhasAfetadas = await _context.SaveChangesAsync();
                return Ok(linhasAfetadas);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        */

    }
}
