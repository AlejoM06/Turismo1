using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Data;
using Turismo.SHARED.Entities;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/tipopagos")]
    public class TipoPagoController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoPagoController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult> Get()
        {

            return Ok(await _context.TipoPagos.ToListAsync());

        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var tipoPagos = await _context.TipoPagos.FirstOrDefaultAsync(c => c.Id == id);

            if (tipoPagos == null)
            {
                return NotFound();//404
            }

            return Ok(tipoPagos);//200

        }

        [HttpPost]

        public async Task<ActionResult> Post(TipoPago tipoPago)
        {
            _context.Add(tipoPago);
            await _context.SaveChangesAsync();
            return Ok(tipoPago);
        }

        [HttpPut]

        public async Task<ActionResult> Put(TipoPago tipoPago)
        {
            _context.Update(tipoPago);
            await _context.SaveChangesAsync();
            return Ok(tipoPago);
        }

        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.TipoPagos.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404
            }

            return NoContent();//204
        }
    }
}
