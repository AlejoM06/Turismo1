using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Api.Helpers;
using Turismos.Shared.DTOs;
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
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Facturas
                .Include(factura => factura.Cliente)
                .Include(factura => factura.TipoPago)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Fecha.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
            .OrderBy(x => x.Fecha)
            .Paginate(pagination)
            .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Facturas.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Fecha.ToLower().Contains(pagination.Filter.ToLower()));
            }
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var factura = await _context.Facturas
                .Include(f => f.Cliente)
                .Include(f => f.TipoPago)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (factura == null)
            {
                return NotFound();//404


            }

            return Ok(factura);//200

        }

        [HttpGet("full")]
        public async Task<ActionResult<IEnumerable<Factura>>> GetFull()
        {
            return await _context.Facturas
                .Include(factura => factura.Cliente)
                .ThenInclude(cliente => cliente.Comentarios)
                .Include(factura => factura.Transporte)
                .ThenInclude(transporte => transporte.Viajes)
                .ToListAsync();
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
