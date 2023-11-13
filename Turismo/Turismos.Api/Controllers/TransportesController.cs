using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/transportes")]
    public class TransportesController : ControllerBase
    {
        private readonly DataContext _context;

        public TransportesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Transportes
                        .Include(t => t.Viajes)
                        .ToListAsync());

        }


        //Get por parámetro--- id

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var transporte = await _context.Transportes
                .Include(t => t.Viajes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (transporte == null)
            {
                return NotFound();//404


            }

            return Ok(transporte);//200

        }

        [HttpGet("full")]
        public async Task<ActionResult<IEnumerable<Transporte>>> GetFull()
        {
            var transportesConViajes = await _context.Transportes
                .Include(t => t.Viajes)
                .ToListAsync();

            return Ok(transportesConViajes);
        }


        [HttpPost]
        public async Task<ActionResult> Post(Transporte transporte)
        {
            _context.Add(transporte);
            await _context.SaveChangesAsync();
            return Ok(transporte);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Transporte transporte)
        {
            _context.Update(transporte);
            await _context.SaveChangesAsync();
            return Ok(transporte);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Transportes
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
