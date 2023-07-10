using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.Controllers
{
    public class TblBansController : Controller
    {
        private readonly QuanLyDaiHocContext _context;
        private readonly ITblBanServices _banServices;

        public TblBansController(QuanLyDaiHocContext context, ITblBanServices banServices)
        {
            _context = context;
            _banServices = banServices;
        }

        // GET: TblBans
        public async Task<IActionResult> Index()
        {
            List<TblBan> ban = _banServices.GetTblBans();
              return _context.TblBans != null ? 
                          View(await _context.TblBans.ToListAsync()) :
                          Problem("Entity set 'QuanLyDaiHocContext.TblBans'  is null.");
        }

        // GET: TblBans/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBans == null)
            {
                return NotFound();
            }

            var tblBan = await _context.TblBans
                .FirstOrDefaultAsync(m => m.MaBan == id);
            if (tblBan == null)
            {
                return NotFound();
            }

            return View(tblBan);
        }

        // GET: TblBans/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TblBans/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaBan,TenBan,TruongBan,NgayThanhLap,Sdt,Email")] TblBan tblBan)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBan);
        }

        // GET: TblBans/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblBans == null)
            {
                return NotFound();
            }

            var tblBan = await _context.TblBans.FindAsync(id);
            if (tblBan == null)
            {
                return NotFound();
            }
            return View(tblBan);
        }

        // POST: TblBans/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaBan,TenBan,TruongBan,NgayThanhLap,Sdt,Email")] TblBan tblBan)
        {
            if (id != tblBan.MaBan)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBan);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBanExists(tblBan.MaBan))
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
            return View(tblBan);
        }

        // GET: TblBans/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblBans == null)
            {
                return NotFound();
            }

            var tblBan = await _context.TblBans
                .FirstOrDefaultAsync(m => m.MaBan == id);
            if (tblBan == null)
            {
                return NotFound();
            }

            return View(tblBan);
        }

        // POST: TblBans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblBans == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.TblBans'  is null.");
            }
            var tblBan = await _context.TblBans.FindAsync(id);
            if (tblBan != null)
            {
                _context.TblBans.Remove(tblBan);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBanExists(int id)
        {
          return (_context.TblBans?.Any(e => e.MaBan == id)).GetValueOrDefault();
        }
    }
}
