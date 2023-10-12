using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.Shared.Entities;
using Turismo.API.Data;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/viaje")]
    public class ViajesController : ControllerBase

        {

            private readonly DataContext _context;

            public ViajesController(DataContext context)
            {
                _context = context;

            }

            [HttpGet]
            public async Task<ActionResult> Get()
            {

                return Ok(await _context.Viajes.ToListAsync());

            }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {

                var viaje = await _context.Viajes.FirstOrDefaultAsync(c => c.Id == id);

                if (viaje == null)
                {
                    return NotFound();//404
                }

                return Ok(viaje);//200

            }
            [HttpPost]

            public async Task<ActionResult> Post(Viaje viaje)
            {
                _context.Add(viaje);
                await _context.SaveChangesAsync();
                return Ok(viaje);
            }

            [HttpPut]

            public async Task<ActionResult> Put(Viaje viaje)
            {
                _context.Update(viaje);
                await _context.SaveChangesAsync();
                return Ok(viaje);
            }
            [HttpDelete("{id:int}")]

            public async Task<ActionResult> Delete(int id)
            {
                var filaafectada = await _context.Viajes.Where(c => c.Id == id).ExecuteDeleteAsync();

                if (filaafectada == 0)
                {
                    return NotFound();//404
                }

                return NoContent();//204
            }
        }
}
