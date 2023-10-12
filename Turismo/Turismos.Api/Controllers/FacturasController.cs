using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/factura")]
    public class FacturasController : ControllerBase
    {
        private readonly DataContext _context;

        public FacturasController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {


            return Ok(await _context.Facturas.ToListAsync());

        }


        //Get por parámetro--- id

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var factura = await _context.Facturas.FirstOrDefaultAsync(c => c.Id == id);

            if (factura == null)
            {
                return NotFound();//404


            }

            return Ok(factura);//200

        }

        [HttpPost]
        public async Task<ActionResult> Post(Factura factura)
        {
            _context.Add(factura);
            await _context.SaveChangesAsync();
            return Ok(factura);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Factura factura)
        {
            _context.Update(factura);
            await _context.SaveChangesAsync();
            return Ok(factura);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Facturas
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
