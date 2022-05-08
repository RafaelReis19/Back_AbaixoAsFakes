using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AbaixoAsFakesApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VotosController : ControllerBase
    {
        private readonly DataContext _context;

        public VotosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
        }

        [Authorize]
        [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarVoto(Voto voto)
        {
            try
            {
                if (voto == null)
                    throw new ArgumentNullException("Voto inválido");

                voto.IdUsuario = ObterIdUsuario();

                if (await _context.Usuarios.AnyAsync(x => x.Id == voto.IdUsuario) == false)
                    throw new ArgumentNullException("Usuário inválido");

                if(await _context.Noticias.AnyAsync(x => x.Id == voto.IdNoticia) == false)
                    throw new ArgumentNullException("Notícia não encontrada");

                await _context.Votos.AddAsync(voto);
                await _context.SaveChangesAsync();

                return Ok(voto.TipoVoto);
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
                List<Voto> lista = await _context.Votos.ToListAsync();
                return Ok(lista);
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
    }
}
