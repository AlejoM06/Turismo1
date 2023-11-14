using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Turismos.Api.Data;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{
    [ApiController]
    [Route("/api/cliente")]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return Ok(clientes);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Comentarios)
                .Include(c => c.Facturas)
                .Include(c => c.Viajes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(); // 404
            }

            return Ok(cliente); // 200
        }
        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            var clientes = await _context.Clientes
                .Include(c => c.Comentarios)
                .Include(c => c.Facturas)
                .Include(c => c.Viajes)
                .ToListAsync();

            return Ok(clientes);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            _context.Add(cliente);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(cliente); // 200
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un cliente con el mismo documento.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Put(Cliente cliente)
        {
            _context.Update(cliente);
            try
            {
                await _context.SaveChangesAsync();
                return Ok(cliente); // 200
            }
            catch (DbUpdateException dbUpdateException)
            {
                if (dbUpdateException.InnerException!.Message.Contains("duplicate"))
                {
                    return BadRequest("Ya existe un cliente con el mismo documento.");
                }
                else
                {
                    return BadRequest(dbUpdateException.InnerException.Message);
                }
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var cliente = await _context.Clientes
                .Include(c => c.Comentarios)
                .Include(c => c.Facturas)
                .Include(c => c.Viajes)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound(); // 404
            }

            // Eliminar entidades relacionadas
            _context.Comentarios.RemoveRange(cliente.Comentarios);
            _context.Facturas.RemoveRange(cliente.Facturas);
            _context.Viajes.RemoveRange(cliente.Viajes);

            // Eliminar el cliente
            _context.Clientes.Remove(cliente);

            await _context.SaveChangesAsync();

            return NoContent(); // 204   
        }
    }
}
