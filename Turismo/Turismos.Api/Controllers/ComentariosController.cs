using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Turismos.Api.Data;
using Turismos.Api.Helpers;
using Turismos.Shared.DTOs;
using Turismos.Shared.Entities;

namespace Turismos.Api.Controllers
{

    [ApiController]
    [Route("/api/comentarios")]
    public class ComentariosController : ControllerBase
    {

        private readonly DataContext _context;

        public ComentariosController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Comentarios
                .Include(c => c.Calificacion)
                .AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Calificacion.ToLower().Contains(pagination.Filter.ToLower()));
            }
            return Ok(await queryable
            .OrderBy(x => x.Calificacion)
            .Paginate(pagination)
            .ToListAsync());

        }

        [HttpGet("totalPages")]
        public async Task<ActionResult> GetPages([FromQuery] PaginationDTO pagination)
        {
            var queryable = _context.Comentarios.AsQueryable();
            if (!string.IsNullOrWhiteSpace(pagination.Filter))
            {
                queryable = queryable.Where(x => x.Calificacion.ToLower().Contains(pagination.Filter.ToLower()));
            }
            double count = await queryable.CountAsync();
            double totalPages = Math.Ceiling(count / pagination.RecordsNumber);
            return Ok(totalPages);
        }


        [HttpGet("{id:int}")]
        public async Task<ActionResult> Get(int id)
        {


            var comentario = await _context.Comentarios
                .Include(c => c.Cliente)  
                .FirstOrDefaultAsync(c => c.Id == id);

            if (comentario == null)
            {
                return NotFound();//404


            }

            return Ok(comentario);//200

        }

        [HttpGet("full")]
        public async Task<ActionResult> GetFull()
        {
            var comentarios = await _context.Comentarios
                .Include(c => c.Cliente)
                .ToListAsync();

            return Ok(comentarios);
        }

        [HttpPost]
        public async Task<ActionResult> Post(Comentario comentario)
        {
            _context.Add(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);//200
        }



        [HttpPut]
        public async Task<ActionResult> Put(Comentario comentario)
        {
            _context.Update(comentario);
            await _context.SaveChangesAsync();
            return Ok(comentario);//200
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Comentarios
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
