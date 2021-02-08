using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using T24_Ejercici1.Modelos;

namespace T24_Ejercici1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AsignadoAsController : ControllerBase
    {
        private readonly APIContext _context;

        public AsignadoAsController(APIContext context)
        {
            _context = context;
        }

        // GET: api/AsignadoAs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AsignadoA>>> GetAsignados()
        {
            return await _context.Asignados.ToListAsync();
        }

        // GET: api/AsignadoAs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AsignadoA>> GetAsignadoA(int id)
        {
            var asignadoA = await _context.Asignados.FindAsync(id);

            if (asignadoA == null)
            {
                return NotFound();
            }

            return asignadoA;
        }

        // PUT: api/AsignadoAs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAsignadoA(int id, AsignadoA asignadoA)
        {
            if (id != asignadoA.id)
            {
                return BadRequest();
            }

            _context.Entry(asignadoA).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AsignadoAExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/AsignadoAs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AsignadoA>> PostAsignadoA(AsignadoA asignadoA)
        {
            _context.Asignados.Add(asignadoA);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAsignadoA", new { id = asignadoA.id }, asignadoA);
        }

        // DELETE: api/AsignadoAs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AsignadoA>> DeleteAsignadoA(int id)
        {
            var asignadoA = await _context.Asignados.FindAsync(id);
            if (asignadoA == null)
            {
                return NotFound();
            }

            _context.Asignados.Remove(asignadoA);
            await _context.SaveChangesAsync();

            return asignadoA;
        }

        private bool AsignadoAExists(int id)
        {
            return _context.Asignados.Any(e => e.id == id);
        }
    }
}
