using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Veterinaria.API.Data;
using Veterinaria.API.Models;

namespace Veterinaria.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitaProductosController : ControllerBase
    {
        private readonly VeterinariaDbContext _context;

        public CitaProductosController(VeterinariaDbContext context)
        {
            _context = context;
        }

        // GET: api/CitaProductos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CitaProducto>>> GetCitaProductos()
        {
            return await _context.CitaProductos
                .Include(cp => cp.Cita)
                .Include(cp => cp.Producto)
                .ToListAsync();
        }

        // GET: api/CitaProductos/5/10
        [HttpGet("{idCita}/{idProducto}")]
        public async Task<ActionResult<CitaProducto>> GetCitaProducto(int idCita, int idProducto)
        {
            var citaProducto = await _context.CitaProductos
                .Include(cp => cp.Cita)
                .Include(cp => cp.Producto)
                .FirstOrDefaultAsync(cp => cp.IdCita == idCita && cp.IdProducto == idProducto);

            if (citaProducto == null) return NotFound();
            return citaProducto;
        }

        // POST: api/CitaProductos
        [HttpPost]
        public async Task<ActionResult<CitaProducto>> PostCitaProducto(CitaProducto citaProducto)
        {
            _context.CitaProductos.Add(citaProducto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetCitaProducto), new { idCita = citaProducto.IdCita, idProducto = citaProducto.IdProducto }, citaProducto);
        }

        // PUT: api/CitaProductos/5/10
        [HttpPut("{idCita}/{idProducto}")]
        public async Task<IActionResult> PutCitaProducto(int idCita, int idProducto, CitaProducto citaProducto)
        {
            if (idCita != citaProducto.IdCita || idProducto != citaProducto.IdProducto)
                return BadRequest();

            _context.Entry(citaProducto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.CitaProductos.Any(e => e.IdCita == idCita && e.IdProducto == idProducto))
                    return NotFound();
                else throw;
            }

            return NoContent();
        }

        // DELETE: api/CitaProductos/5/10
        [HttpDelete("{idCita}/{idProducto}")]
        public async Task<IActionResult> DeleteCitaProducto(int idCita, int idProducto)
        {
            var citaProducto = await _context.CitaProductos.FindAsync(idCita, idProducto);
            if (citaProducto == null) return NotFound();

            _context.CitaProductos.Remove(citaProducto);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
