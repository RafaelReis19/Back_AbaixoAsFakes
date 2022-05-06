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
    public class ComentariosController : ControllerBase
    {
        IConfiguration _configuration;
        DataContext _context;

        public ComentariosController(IConfiguration configuration, DataContext context)
        {
            _configuration = configuration;
            _context = context;
        }

        /*
         * [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarComentario(Comentario novoComent)
        {
            try
            {
                await _context.Comentarios.AddAsync(novoComent);
                await _context.SaveChangesAsync(); 

                //return CreatedAtAction(nameof(GetTodoItem) = new { id = user.idUsuario }, user);
                return Ok(novoComent.idComentario);
            }
            catch (System.Exception ex)
            {   
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Comentario> lista = await _context.Comentarios.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {               
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{idComent}")]
        public async Task<IActionResult> Delete(int idComent)
        {
            try
            {
                 Comentario cRemover = await _context.Comentarios.FirstOrDefaultAsync(c => c.idComentario == idComent);
                 _context.Comentarios.Remove(cRemover);
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
