using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            return Ok(await _context.Clientes.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var cliente = await _context.Clientes.FirstOrDefaultAsync(c => c.Id == id);

            if (cliente == null)
            {
                return NotFound();//404


            }

            return Ok(cliente);//200

        }



        [HttpPost]
        public async Task<ActionResult> Post(Cliente cliente)
        {
            _context.Add(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);//200
        }


        [HttpPut]
        public async Task<ActionResult> Put(Cliente cliente)
        {
            _context.Update(cliente);
            await _context.SaveChangesAsync();
            return Ok(cliente);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Clientes
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
