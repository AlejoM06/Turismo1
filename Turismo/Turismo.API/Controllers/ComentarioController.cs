using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Data;
using Turismo.SHARED.Entities;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/comentarios")]

    public class ComentarioController : ControllerBase
    {

        private readonly DataContext _context;

        public ComentarioController(DataContext context)
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
            return Ok(comentario);
        }

        [HttpPut]

        public async Task<ActionResult> Put(Comentario comentario)
        {
            _context.Update(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.Comentarios.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404
            }

            return NoContent();//204
        }

    }
}
