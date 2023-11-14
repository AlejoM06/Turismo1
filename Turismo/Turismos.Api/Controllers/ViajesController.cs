using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/viajes")]
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


            return Ok(await _context.Viajes
                .Include(v => v.Cliente)
                .Include(v => v.Hotel)
                .Include(v => v.Transporte)
                .ToListAsync());
        }


        //Get por parámetro--- id

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var viaje = await _context.Viajes
                .Include(v => v.Cliente)
                .Include(v => v.Hotel)
                .Include(v => v.Transporte)
                .FirstOrDefaultAsync(c => c.Id == id);

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
            return Ok(viaje);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Viaje viaje)
        {
            _context.Update(viaje);
            await _context.SaveChangesAsync();
            return Ok(viaje);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Viajes
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
