using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.Shared.Entities;
using Turismo.API.Data;
namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/celebracion")]
    public class CelebracionesController : ControllerBase

        {

            private readonly DataContext _context;

            public CelebracionesController(DataContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {

                return Ok(await _context.Celebraciones.ToListAsync());

            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {

                var celebracion = await _context.Celebraciones.FirstOrDefaultAsync(c => c.Id == id);

                if (celebracion == null)
                {
                    return NotFound();//404
                }

                return Ok(celebracion);//200

            }
            [HttpPost]

            public async Task<ActionResult> Post(Celebracion celebracion)
            {
                _context.Add(celebracion);
                await _context.SaveChangesAsync();
                return Ok(celebracion);
            }

            [HttpPut]

            public async Task<ActionResult> Put(Celebracion celebracion)
            {
                _context.Update(celebracion);
                await _context.SaveChangesAsync();
                return Ok(celebracion);
            }
            [HttpDelete("{id:int}")]

            public async Task<ActionResult> Delete(int id)
            {
                var filaafectada = await _context.Celebraciones.Where(c => c.Id == id).ExecuteDeleteAsync();

                if (filaafectada == 0)
                {
                    return NotFound();//404
                }

                return NoContent();//204
            }
        }
}
