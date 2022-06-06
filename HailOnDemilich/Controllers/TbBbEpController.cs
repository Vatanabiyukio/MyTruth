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
    public class TbBbEpController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TbBbEpController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TbBbEp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBbEp>>> GetTbBbEps()
        {
            if (_context.TbBbEps == null)
            {
                return NotFound();
            }

            return await _context.TbBbEps.ToListAsync();
        }

        // GET: api/TbBbEp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBbEp>> GetTbBbEp(string id)
        {
            if (_context.TbBbEps == null)
            {
                return NotFound();
            }

            var tbBbEp = await _context.TbBbEps.FindAsync(id);

            if (tbBbEp == null)
            {
                return NotFound();
            }

            return tbBbEp;
        }

        // PUT: api/TbBbEp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBbEp(string id, TbBbEp tbBbEp)
        {
            if (id != tbBbEp.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(tbBbEp).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBbEpExists(id))
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

        // POST: api/TbBbEp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBbEp>> PostTbBbEp(TbBbEp tbBbEp)
        {
            if (_context.TbBbEps == null)
            {
                return Problem("Entity set 'MyDbContext.TbBbEps'  is null.");
            }

            _context.TbBbEps.Add(tbBbEp);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbBbEpExists(tbBbEp.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbBbEp", new { id = tbBbEp.Cpf }, tbBbEp);
        }

        // DELETE: api/TbBbEp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBbEp(string id)
        {
            if (_context.TbBbEps == null)
            {
                return NotFound();
            }

            var tbBbEp = await _context.TbBbEps.FindAsync(id);
            if (tbBbEp == null)
            {
                return NotFound();
            }

            _context.TbBbEps.Remove(tbBbEp);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBbEpExists(string id)
        {
            return (_context.TbBbEps?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}