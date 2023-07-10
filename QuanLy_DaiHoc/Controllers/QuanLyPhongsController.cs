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
    public class QuanLyPhongsController : Controller
    {
        private readonly QuanLyDaiHocContext _context;
        private readonly IQuanLyPhongServices _quanLyPhongServices;

        public QuanLyPhongsController(QuanLyDaiHocContext context, IQuanLyPhongServices quanLyPhongServices)
        {
            _context = context;
            _quanLyPhongServices = quanLyPhongServices;
        }

        // GET: QuanLyPhongs
        public async Task<IActionResult> Index()
        {
            List<QuanLyPhong> qlp = _quanLyPhongServices.GetQuanLyPhong();
              return _context.QuanLyPhongs != null ? 
                          View(qlp) :
                          Problem("Entity set 'QuanLyDaiHocContext.QuanLyPhongs'  is null.");
        }

        // GET: QuanLyPhongs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.QuanLyPhongs == null)
            {
                return NotFound();
            }

            var quanLyPhong = await _context.QuanLyPhongs
                .FirstOrDefaultAsync(m => m.Idphong == id);
            if (quanLyPhong == null)
            {
                return NotFound();
            }

            return View(quanLyPhong);
        }

        // GET: QuanLyPhongs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: QuanLyPhongs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Idphong,TenP,Sdt,Dcm")] QuanLyPhong quanLyPhong)
        {
            if (ModelState.IsValid)
            {
                _context.Add(quanLyPhong);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(quanLyPhong);
        }

        // GET: QuanLyPhongs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.QuanLyPhongs == null)
            {
                return NotFound();
            }

            var quanLyPhong = await _context.QuanLyPhongs.FindAsync(id);
            if (quanLyPhong == null)
            {
                return NotFound();
            }
            return View(quanLyPhong);
        }

        // POST: QuanLyPhongs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Idphong,TenP,Sdt,Dcm")] QuanLyPhong quanLyPhong)
        {
            if (id != quanLyPhong.Idphong)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(quanLyPhong);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QuanLyPhongExists(quanLyPhong.Idphong))
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
            return View(quanLyPhong);
        }

        // GET: QuanLyPhongs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.QuanLyPhongs == null)
            {
                return NotFound();
            }

            var quanLyPhong = await _context.QuanLyPhongs
                .FirstOrDefaultAsync(m => m.Idphong == id);
            if (quanLyPhong == null)
            {
                return NotFound();
            }

            return View(quanLyPhong);
        }

        // POST: QuanLyPhongs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.QuanLyPhongs == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.QuanLyPhongs'  is null.");
            }
            var quanLyPhong = await _context.QuanLyPhongs.FindAsync(id);
            if (quanLyPhong != null)
            {
                _context.QuanLyPhongs.Remove(quanLyPhong);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool QuanLyPhongExists(int id)
        {
          return (_context.QuanLyPhongs?.Any(e => e.Idphong == id)).GetValueOrDefault();
        }
    }
}
