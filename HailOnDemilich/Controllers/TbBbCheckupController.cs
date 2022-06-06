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
    public class TbBbCheckupController : ControllerBase
    {
        private readonly MyDbContext _context;

        public TbBbCheckupController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/TbBbCheckup
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TbBbCheckup>>> GetTbBbCheckups()
        {
            if (_context.TbBbCheckups == null)
            {
                return NotFound();
            }

            return await _context.TbBbCheckups.ToListAsync();
        }

        // GET: api/TbBbCheckup/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TbBbCheckup>> GetTbBbCheckup(string id)
        {
            if (_context.TbBbCheckups == null)
            {
                return NotFound();
            }

            var tbBbCheckup = await _context.TbBbCheckups.FindAsync(id);

            if (tbBbCheckup == null)
            {
                return NotFound();
            }

            return tbBbCheckup;
        }

        // PUT: api/TbBbCheckup/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTbBbCheckup(string id, TbBbCheckup tbBbCheckup)
        {
            if (id != tbBbCheckup.Cpf)
            {
                return BadRequest();
            }

            _context.Entry(tbBbCheckup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TbBbCheckupExists(id))
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

        // POST: api/TbBbCheckup
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TbBbCheckup>> PostTbBbCheckup(TbBbCheckup tbBbCheckup)
        {
            if (_context.TbBbCheckups == null)
            {
                return Problem("Entity set 'MyDbContext.TbBbCheckups'  is null.");
            }

            _context.TbBbCheckups.Add(tbBbCheckup);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TbBbCheckupExists(tbBbCheckup.Cpf))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTbBbCheckup", new { id = tbBbCheckup.Cpf }, tbBbCheckup);
        }

        // DELETE: api/TbBbCheckup/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTbBbCheckup(string id)
        {
            if (_context.TbBbCheckups == null)
            {
                return NotFound();
            }

            var tbBbCheckup = await _context.TbBbCheckups.FindAsync(id);
            if (tbBbCheckup == null)
            {
                return NotFound();
            }

            _context.TbBbCheckups.Remove(tbBbCheckup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TbBbCheckupExists(string id)
        {
            return (_context.TbBbCheckups?.Any(e => e.Cpf == id)).GetValueOrDefault();
        }
    }
}