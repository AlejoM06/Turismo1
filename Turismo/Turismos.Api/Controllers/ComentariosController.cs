using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{

    [ApiController]
    [Route("/api/comentarios")]
    public class ComentariosController : ControllerBase
    {

        private readonly DataContext _context;

        public ComentariosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Comentarios.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var comentario = await _context.Comentarios.FirstOrDefaultAsync(c => c.Id == id);

            if (comentario == null)
            {
                return NotFound();//404


            }

            return Ok(comentario);//200

        }

        [HttpPost]
        public async Task<ActionResult> Post(Comentario comentario)
        {
            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Comentario comentario)
        {
            _context.Update(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Comentarios
                .Where(c => c.Id == id)
                .ExecuteDeleteAsync();

            if (filaafectada == 0)
            {


                return NotFound();// 404

            }

            return NoContent();//204   

        }

    }
}
