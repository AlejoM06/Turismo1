using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Api.Helpers;
using Turismos.Shared.DTOs;
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
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TipoPagos
                .Include(tp => tp.Facturas)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.TDebito.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
            .OrderBy(x => x.Id)
            .Paginate(pagination)
            .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.TipoPagos.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.TDebito.ToLower().Contains(pagination.Filter.ToLower()));
            }
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }



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
