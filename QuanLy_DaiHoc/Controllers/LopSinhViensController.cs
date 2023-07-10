using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.Controllers
{
    public class LopSinhViensController : Controller
    {
        private readonly QuanLyDaiHocContext _context;

        public LopSinhViensController(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        // GET: LopSinhViens
        public async Task<IActionResult> Index()
        {
            var quanLyDaiHocContext = _context.LopSinhViens.Include(l => l.IdLopTinChiNavigation).Include(l => l.MaSinhVienNavigation);
            return View(await quanLyDaiHocContext.ToListAsync());
        }

        // GET: LopSinhViens/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LopSinhViens == null)
            {
                return NotFound();
            }

            var lopSinhVien = await _context.LopSinhViens
                .Include(l => l.IdLopTinChiNavigation)
                .Include(l => l.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.IdLopSinhVien == id);
            if (lopSinhVien == null)
            {
                return NotFound();
            }

            return View(lopSinhVien);
        }

        // GET: LopSinhViens/Create
        public IActionResult Create()
        {
            ViewData["IdLopTinChi"] = new SelectList(_context.LopTinChis, "IdLopTinChi", "IdLopTinChi");
            ViewData["MaSinhVien"] = new SelectList(_context.NguoiDungs, "IdNguoiDung", "IdNguoiDung");
            return View();
        }

        // POST: LopSinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLopSinhVien,MaSinhVien,IdLopTinChi")] LopSinhVien lopSinhVien)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lopSinhVien);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLopTinChi"] = new SelectList(_context.LopTinChis, "IdLopTinChi", "IdLopTinChi", lopSinhVien.IdLopTinChi);
            ViewData["MaSinhVien"] = new SelectList(_context.NguoiDungs, "IdNguoiDung", "IdNguoiDung", lopSinhVien.MaSinhVien);
            return View(lopSinhVien);
        }

        // GET: LopSinhViens/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LopSinhViens == null)
            {
                return NotFound();
            }

            var lopSinhVien = await _context.LopSinhViens.FindAsync(id);
            if (lopSinhVien == null)
            {
                return NotFound();
            }
            ViewData["IdLopTinChi"] = new SelectList(_context.LopTinChis, "IdLopTinChi", "IdLopTinChi", lopSinhVien.IdLopTinChi);
            ViewData["MaSinhVien"] = new SelectList(_context.NguoiDungs, "IdNguoiDung", "IdNguoiDung", lopSinhVien.MaSinhVien);
            return View(lopSinhVien);
        }

        // POST: LopSinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLopSinhVien,MaSinhVien,IdLopTinChi")] LopSinhVien lopSinhVien)
        {
            if (id != lopSinhVien.IdLopSinhVien)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lopSinhVien);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopSinhVienExists(lopSinhVien.IdLopSinhVien))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdLopTinChi"] = new SelectList(_context.LopTinChis, "IdLopTinChi", "IdLopTinChi", lopSinhVien.IdLopTinChi);
            ViewData["MaSinhVien"] = new SelectList(_context.NguoiDungs, "IdNguoiDung", "IdNguoiDung", lopSinhVien.MaSinhVien);
            return View(lopSinhVien);
        }

        // GET: LopSinhViens/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LopSinhViens == null)
            {
                return NotFound();
            }

            var lopSinhVien = await _context.LopSinhViens
                .Include(l => l.IdLopTinChiNavigation)
                .Include(l => l.MaSinhVienNavigation)
                .FirstOrDefaultAsync(m => m.IdLopSinhVien == id);
            if (lopSinhVien == null)
            {
                return NotFound();
            }

            return View(lopSinhVien);
        }

        // POST: LopSinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LopSinhViens == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.LopSinhViens'  is null.");
            }
            var lopSinhVien = await _context.LopSinhViens.FindAsync(id);
            if (lopSinhVien != null)
            {
                _context.LopSinhViens.Remove(lopSinhVien);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LopSinhVienExists(int id)
        {
          return (_context.LopSinhViens?.Any(e => e.IdLopSinhVien == id)).GetValueOrDefault();
        }
    }
}
