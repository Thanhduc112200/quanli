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
    public class Khoas1Controller : ControllerBase
    {
        private readonly QuanLyDaiHocContext _context;

        public Khoas1Controller(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        // GET: api/Khoas1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Khoa>>> GetKhoas()
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            return await _context.Khoas.ToListAsync();
        }

        // GET: api/Khoas1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Khoa>> GetKhoa(int id)
        {
          if (_context.Khoas == null)
          {
              return NotFound();
          }
            var khoa = await _context.Khoas.FindAsync(id);

            if (khoa == null)
            {
                return NotFound();
            }

            return khoa;
        }

        // PUT: api/Khoas1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKhoa(int id, Khoa khoa)
        {
            if (id != khoa.KhoaId)
            {
                return BadRequest();
            }

            _context.Entry(khoa).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KhoaExists(id))
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

        // POST: api/Khoas1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Khoa>> PostKhoa(Khoa khoa)
        {
          if (_context.Khoas == null)
          {
              return Problem("Entity set 'QuanLyDaiHocContext.Khoas'  is null.");
          }
            _context.Khoas.Add(khoa);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (KhoaExists(khoa.KhoaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetKhoa", new { id = khoa.KhoaId }, khoa);
        }

        // DELETE: api/Khoas1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKhoa(int id)
        {
            if (_context.Khoas == null)
            {
                return NotFound();
            }
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }

            _context.Khoas.Remove(khoa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KhoaExists(int id)
        {
            return (_context.Khoas?.Any(e => e.KhoaId == id)).GetValueOrDefault();
        }
    }
}
