﻿using System;
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
    public class CientificoesController : ControllerBase
    {
        private readonly APIContext _context;

        public CientificoesController(APIContext context)
        {
            _context = context;
        }

        // GET: api/Cientificoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cientifico>>> GetCientificos()
        {
            return await _context.Cientificos.ToListAsync();
        }

        // GET: api/Cientificoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cientifico>> GetCientifico(int id)
        {
            var cientifico = await _context.Cientificos.FindAsync(id);

            if (cientifico == null)
            {
                return NotFound();
            }

            return cientifico;
        }

        // PUT: api/Cientificoes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCientifico(int id, Cientifico cientifico)
        {
            if (id != cientifico.id)
            {
                return BadRequest();
            }

            _context.Entry(cientifico).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CientificoExists(id))
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

        // POST: api/Cientificoes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Cientifico>> PostCientifico(Cientifico cientifico)
        {
            _context.Cientificos.Add(cientifico);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCientifico", new { id = cientifico.id }, cientifico);
        }

        // DELETE: api/Cientificoes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Cientifico>> DeleteCientifico(int id)
        {
            var cientifico = await _context.Cientificos.FindAsync(id);
            if (cientifico == null)
            {
                return NotFound();
            }

            _context.Cientificos.Remove(cientifico);
            await _context.SaveChangesAsync();

            return cientifico;
        }

        private bool CientificoExists(int id)
        {
            return _context.Cientificos.Any(e => e.id == id);
        }
    }
}
