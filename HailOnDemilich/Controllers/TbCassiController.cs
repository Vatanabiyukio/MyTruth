using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HailOnDemilich.Context;
using HailOnDemilich.Entities;

namespace HailOnDemilich.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TbCassiController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TbCassiController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TbCassi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbCassi>>> GetTbCassis()
        {
            if (_context.TbCassis == null)
            {
                return NotFound();
            }

            return await _context.TbCassis.ToListAsync();
        }

        // GET: api/TbCassi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbCassi>> GetTbCassi(string id)
        {
            if (_context.TbCassis == null)
            {
                return NotFound();
            }

            var tbCassi = await _context.TbCassis.FindAsync(id);

            if (tbCassi == null)
            {
                return NotFound();
            }

            return tbCassi;
        }

        // PUT: api/TbCassi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbCassi(string id, TbCassi tbCassi)
        {
            if (id != tbCassi.NumCpf)
            {
                return BadRequest();
            }

            _context.Entry(tbCassi).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbCassiExists(id))
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

        // POST: api/TbCassi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbCassi>> PostTbCassi(TbCassi tbCassi)
        {
            if (_context.TbCassis == null)
            {
                return Problem("Entity set 'MyDbContext.TbCassis'  is null.");
            }

            _context.TbCassis.Add(tbCassi);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbCassiExists(tbCassi.NumCpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbCassi", new { id = tbCassi.NumCpf }, tbCassi);
        }

        // DELETE: api/TbCassi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbCassi(string id)
        {
            if (_context.TbCassis == null)
            {
                return NotFound();
            }

            var tbCassi = await _context.TbCassis.FindAsync(id);
            if (tbCassi == null)
            {
                return NotFound();
            }

            _context.TbCassis.Remove(tbCassi);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbCassiExists(string id)
        {
            return (_context.TbCassis?.Any(e => e.NumCpf == id)).GetValueOrDefault();
        }
    }
}