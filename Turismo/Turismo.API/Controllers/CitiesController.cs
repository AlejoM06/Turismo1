using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Data;
using Turismo.Shared.Entities;
using Turismo.SHARED.Entities;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/cities")]

    public class CitiesController : ControllerBase
    {

        private readonly DataContext _context;

        public CitiesController(DataContext context)
        {
            _context = context;

        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Cities.ToListAsync());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {

            var city = await _context.Cities.FirstOrDefaultAsync(c => c.Id == id);

            if (city == null)
            {
                return NotFound();//404
            }

            return Ok(city);//200

        }
        [HttpPost]

        public async Task<ActionResult> Post(City city)
        {
            _context.Add(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }
        [HttpPut]

        public async Task<ActionResult> Put(City city)
        {
            _context.Update(city);
            await _context.SaveChangesAsync();
            return Ok(city);
        }
        [HttpDelete("{id:int}")]

        public async Task<ActionResult> Delete(int id)
        {
            var filaafectada = await _context.Cities.Where(c => c.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {
                return NotFound();//404
            }

            return NoContent();//204
        }
    }
}
