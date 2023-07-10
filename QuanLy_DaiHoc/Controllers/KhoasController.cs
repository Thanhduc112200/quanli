using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.BusinessLogic.Services;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.Controllers
{
    public class KhoasController : Controller
    {
        private readonly QuanLyDaiHocContext _context;
        private readonly IKhoaServices _khoaServices;

        public KhoasController(QuanLyDaiHocContext context, IKhoaServices khoaServices)
        {
            _context = context;
            _khoaServices = khoaServices;
        }

        //private readonly KhoaServices _khoaServices;

        //public KhoasController(QuanLyDaiHocContext context, KhoaServices khoaServices)
        //{
        //    _context = context;
        //    _khoaServices = khoaServices;
        //}



        // GET: Khoas
        public async Task<IActionResult> Index()
        {

            //List<Khoa> khoa = _khoaServices.GetKhoa();
            List<Khoa> khoa = _khoaServices.GetKhoa();

            return _context.Khoas != null ?
                        View(khoa) :
                        Problem("Entity set 'QuanLyDaiHocContext.Khoas'  is null.");
        }

        // GET: Khoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Khoas == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.KhoaId == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // GET: Khoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Khoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KhoaId,TenKhoa,NgayThanhLap,Mota")] Khoa khoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(khoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(khoa);
        }

        // GET: Khoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Khoas == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa == null)
            {
                return NotFound();
            }
            return View(khoa);
        }

        // POST: Khoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KhoaId,TenKhoa,NgayThanhLap,Mota")] Khoa khoa)
        {
            if (id != khoa.KhoaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(khoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KhoaExists(khoa.KhoaId))
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
            return View(khoa);
        }

        // GET: Khoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Khoas == null)
            {
                return NotFound();
            }

            var khoa = await _context.Khoas
                .FirstOrDefaultAsync(m => m.KhoaId == id);
            if (khoa == null)
            {
                return NotFound();
            }

            return View(khoa);
        }

        // POST: Khoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Khoas == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.Khoas'  is null.");
            }
            var khoa = await _context.Khoas.FindAsync(id);
            if (khoa != null)
            {
                _context.Khoas.Remove(khoa);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KhoaExists(int id)
        {
            return (_context.Khoas?.Any(e => e.KhoaId == id)).GetValueOrDefault();
        }
    }
}
