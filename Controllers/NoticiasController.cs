using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoticiasController : ControllerBase
    {
        DataContext _context;

        public NoticiasController(DataContext context)
        {
            _context = context;
        }

        
        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Noticia> lista = await _context.Noticias.ToListAsync();
                return Ok(lista);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            try
            {
                var noticia = await _context.Noticias.Where(u => u.Id == id).FirstOrDefaultAsync();

                if (noticia == null)
                    throw new ArgumentNullException("Notícia não encontrada");

                return Ok(noticia);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarNoticia(Noticia noticia)
        {
            try
            {
                if (noticia == null)
                    throw new ArgumentNullException("Notícia inválida");

                noticia.IdUsuario = ObterIdUsuario();

                if (_context.Usuarios.Select(x => x.Id == noticia.IdUsuario).First() == false)
                    throw new ArgumentNullException("Usuário Inválido");

                await _context.Noticias.AddAsync(noticia);
                await _context.SaveChangesAsync();

                return Ok(noticia.Id);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        private int ObterIdUsuario()
        {
            return int.Parse(User.FindFirst("Id").Value);
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            try
            {
                var noticia = await _context.Noticias.FirstOrDefaultAsync(n => n.Id == id);

                if (noticia == null)
                    throw new ArgumentNullException("Essa notícia não existe.");

                _context.Noticias.Remove(noticia);

                await _context.SaveChangesAsync();

                return Ok();
                //return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
