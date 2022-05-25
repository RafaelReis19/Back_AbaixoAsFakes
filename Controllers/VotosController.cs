using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
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
                //voto.Formacao = ObterFormacaoAcademica();

                if (await _context.Usuarios.AnyAsync(x => x.Id == voto.IdUsuario) == false)
                    throw new ArgumentNullException("Usuário inválido");

                if (await _context.Noticias.AnyAsync(x => x.Id == voto.IdNoticia) == false)
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
        [HttpGet("{idNot}")]
        public async Task<IActionResult> Get(int idNot)
        {
            try
            {
                //int count;
                var votos = await _context.Votos.Where(u => u.IdNoticia == idNot)
                    .Include(u => u.Usuario)
                    .ToListAsync();//.FirstOrDefaultAsync();
                /*Include(User.FindFirst("Formacao").Value).*/

                //var noticia = await _context.Noticias.Where(u => u.Nome == nome).FirstOrDefaultAsync();

                if (votos == null)
                    throw new ArgumentNullException("Notícia não encontrada");

                return Ok(votos);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //Tentativa falha de executar a procedure
        [HttpGet("{idNoti}")]
        public async /*static*/ Task<List<Voto>> ExecProcedure(int idNoti)
        {
            var param = new SqlParameter("@NOTICIA", idNoti);
            var resul = await _context.Votos.FromSqlRaw("AF_SP_VOTOSPNOTICIA @NOTICIA", param).ToListAsync();
            return resul;
        }

        //SqlServerRetryingExecutionStrategy

        [Authorize]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Voto> lista = await _context.Votos
                    .Include(u => u.Usuario)
                    .ToListAsync();
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

        private int ObterFormacaoAcademica()
        {
            return int.Parse(User.FindFirst("Formacao").Value);
        }
    }
}
