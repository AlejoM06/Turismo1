using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Data;
using Turismo.Shared.Entities;
using Turismo.SHARED.Entities;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/transporte")]
    public class TransporteController : ControllerBase
    {
        private readonly DataContext _context;

        public TransporteController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]

        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Transportes.ToListAsync());
        }


        [HttpGet("{id:int}")]

        public async Task<ActionResult> Get(int id)
        {
            var transporte = await _context.Transportes.FirstOrDefaultAsync(c => c.Id == id);

            if (transporte == null)
            {
                return NotFound();//404
            }

            return Ok(transporte);
        }

        [HttpPost]

        public async Task<ActionResult> Post(Transporte transporte)
        {
            _context.Add(transporte);
            await _context.SaveChangesAsync();
            return Ok(transporte);
        }

        [HttpPut]

        public async Task<ActionResult> Put(Transporte transporte)
        {
            _context.Update(transporte);
            await _context.SaveChangesAsync();
            return Ok(transporte);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Transportes.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404
            }

            return NoContent();
        }

    }
}
