using AbaixoAsFakesApi.Data;
using AbaixoAsFakesApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        private readonly IConfiguration _configuration;
        public VotosController(DataContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        /* [HttpPost("Registrar")]
        public async Task<IActionResult> RegistrarVoto(Voto newVoto)
        {
            try
            {


                //novaNot.idUsuario = _context.Usuarios.Find();

                 //if(novaNot.idUsuario1 != null)
                //{
                    //novaNot.idUsuario1 = _context.Usuarios.FirstOrDefault(uBusca => 
                  //  uBusca.idUsuario == ObterUsuario());
                //}

                await _context.Votos.AddAsync(newVoto);
                await _context.SaveChangesAsync();

                //return CreatedAtAction(nameof(GetTodoItem) = new { id = user.idUsuario }, user);
                return Ok(newVoto.idTipoVoto);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        //[AllowAnonymous]
        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Voto> lista = await _context.Votos.ToListAsync();
                return Ok(lista);
            }
            catch (System.Exception ex)
            {

                return BadRequest(ex.Message);
            }
        } */
    }
}
