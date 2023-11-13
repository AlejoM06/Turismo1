using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/hoteles")]
    public class HotelesController : ControllerBase
    {
        private readonly DataContext _context;

        public HotelesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Hoteles
                .Include(h => h.Viajes)
                .ToListAsync());

        }


        //Get por parámetro--- id

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var hotel = await _context.Hoteles
                 .Include(h => h.Viajes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (hotel == null)
            {
                return NotFound();//404


            }

            return Ok(hotel);//200

        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            var hotelesFull = await _context.Hoteles
                .Include(h => h.Viajes)
                    .ThenInclude(v => v.Cliente)
                        .ThenInclude(c => c.Comentarios)
                .ToListAsync();

            return Ok(hotelesFull);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Hotel hotel)
        {
            _context.Add(hotel);
            await _context.SaveChangesAsync();
            return Ok(hotel);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Hotel hotel)
        {
            _context.Update(hotel);
            await _context.SaveChangesAsync();
            return Ok(hotel);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Hoteles
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
