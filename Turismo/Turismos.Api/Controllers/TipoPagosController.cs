using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/tipopago")]
    public class TipoPagosController : ControllerBase
    {
        private readonly DataContext _context;

        public TipoPagosController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.TipoPagos
                            .Include(tp => tp.Facturas)
                            .ToListAsync());

        }


        //Get por parámetro--- id

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var tipopago = await _context.TipoPagos
                            .Include(tp => tp.Facturas)
                            .FirstOrDefaultAsync(c => c.Id == id);

            if (tipopago == null)
            {
                return NotFound();//404


            }

            return Ok(tipopago);//200

        }

        [HttpPost]
        public async Task<ActionResult> Post(TipoPago tipopago)
        {
            _context.Add(tipopago);
            await _context.SaveChangesAsync();
            return Ok(tipopago);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(TipoPago tipopago)
        {
            _context.Update(tipopago);
            await _context.SaveChangesAsync();
            return Ok(tipopago);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.TipoPagos
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
