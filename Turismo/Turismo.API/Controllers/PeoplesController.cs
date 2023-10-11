using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismo.API.Data;
using Turismo.Shared.Entities;
using Turismo.SHARED.Entities;

namespace Turismo.API.Controllers
{
    [ApiController]
    [Route("/api/people")]
    public class PeoplesController : ControllerBase
    {        

            private readonly DataContext _context;

            public PeoplesController(DataContext context)
            {
                _context = context;

            }


             [HttpGet]
             public async Task<ActionResult> Get()
             {
                 return Ok(await _context.Peoples.ToListAsync());
             }

            [HttpGet("{id:int}")]
            public async Task<ActionResult> Get(int id)
            {

                var people = await _context.Peoples.FirstOrDefaultAsync(c => c.Id == id);

                if (people == null)
                {
                    return NotFound();//404
                }

                return Ok(people);//200

            }
            [HttpPost]

            public async Task<ActionResult> Post(People people)
            {
                _context.Add(people);
                await _context.SaveChangesAsync();
                return Ok(people);
            }
            [HttpPut]

            public async Task<ActionResult> Put(People people)
            {
                _context.Update(people);
                await _context.SaveChangesAsync();
                return Ok(people);
            }
            [HttpDelete("{id:int}")]

            public async Task<ActionResult> Delete(int id)
            {
                var filaafectada = await _context.Peoples.Where(c => c.Id == id).ExecuteDeleteAsync();

                if (filaafectada == 0)
                {
                    return NotFound();//404
                }

                return NoContent();//204
            }
        }
}
