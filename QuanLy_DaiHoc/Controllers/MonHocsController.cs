using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonHocsController : ControllerBase
    {
        private readonly QuanLyDaiHocContext _context;

        public MonHocsController(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        // GET: api/MonHocs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MonHoc>>> GetMonHocs()
        {
          if (_context.MonHocs == null)
          {
              return NotFound();
          }
            return await _context.MonHocs.ToListAsync();
        }

        // GET: api/MonHocs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MonHoc>> GetMonHoc(int id)
        {
          if (_context.MonHocs == null)
          {
              return NotFound();
          }
            var monHoc = await _context.MonHocs.FindAsync(id);

            if (monHoc == null)
            {
                return NotFound();
            }

            return monHoc;
        }

        // PUT: api/MonHocs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMonHoc(int id, MonHoc monHoc)
        {
            if (id != monHoc.IdMonHoc)
            {
                return BadRequest();
            }

            _context.Entry(monHoc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MonHocExists(id))
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

        // POST: api/MonHocs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<MonHoc>> PostMonHoc(MonHoc monHoc)
        {
          if (_context.MonHocs == null)
          {
              return Problem("Entity set 'QuanLyDaiHocContext.MonHocs'  is null.");
          }
            _context.MonHocs.Add(monHoc);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMonHoc", new { id = monHoc.IdMonHoc }, monHoc);
        }

        // DELETE: api/MonHocs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMonHoc(int id)
        {
            if (_context.MonHocs == null)
            {
                return NotFound();
            }
            var monHoc = await _context.MonHocs.FindAsync(id);
            if (monHoc == null)
            {
                return NotFound();
            }

            _context.MonHocs.Remove(monHoc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MonHocExists(int id)
        {
            return (_context.MonHocs?.Any(e => e.IdMonHoc == id)).GetValueOrDefault();
        }
    }
}
