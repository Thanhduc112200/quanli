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
    public class NguoiDungsController : Controller
    {
        private readonly QuanLyDaiHocContext _context;
        private readonly IKhoaServices _khoaServices;
        private readonly INguoiDungServices _nguoiDungServices;

        public NguoiDungsController(QuanLyDaiHocContext context, IKhoaServices khoaServices, INguoiDungServices nguoiDungServices)
        {
            _context = context;
            _khoaServices = khoaServices;
            _nguoiDungServices = nguoiDungServices;
        }

        // GET: NguoiDungs
        public async Task<IActionResult> Index()
        {
            var t = _khoaServices.GetKhoa();

            return _context.NguoiDungs != null ?
                        View(await _context.NguoiDungs.ToListAsync()) :
                        Problem("Entity set 'QuanLyDaiHocContext.NguoiDungs'  is null.");
        }

        // GET: NguoiDungs/Details/5
        public async Task<IActionResult> Details(int id)
        {

            var nguoidung = _nguoiDungServices.GetNguoiDungByID(id);
             
            //var t = nguoidung.NguoiDung.TenNguoiDung 
            //var t = nguoidung.Khoa.NgayThanhLap






            if (id == null || _context.NguoiDungs == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // GET: NguoiDungs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NguoiDungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdNguoiDung,TenNguoiDung,Salt,Md5Password,Password,FieldA")] NguoiDung nguoiDung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(nguoiDung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.NguoiDungs == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung == null)
            {
                return NotFound();
            }
            return View(nguoiDung);
        }

        // POST: NguoiDungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdNguoiDung,TenNguoiDung,Salt,Md5Password,Password,FieldA")] NguoiDung nguoiDung)
        {
            if (id != nguoiDung.IdNguoiDung)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(nguoiDung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NguoiDungExists(nguoiDung.IdNguoiDung))
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
            return View(nguoiDung);
        }

        // GET: NguoiDungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.NguoiDungs == null)
            {
                return NotFound();
            }

            var nguoiDung = await _context.NguoiDungs
                .FirstOrDefaultAsync(m => m.IdNguoiDung == id);
            if (nguoiDung == null)
            {
                return NotFound();
            }

            return View(nguoiDung);
        }

        // POST: NguoiDungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.NguoiDungs == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.NguoiDungs'  is null.");
            }
            var nguoiDung = await _context.NguoiDungs.FindAsync(id);
            if (nguoiDung != null)
            {
                _context.NguoiDungs.Remove(nguoiDung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool NguoiDungExists(int id)
        {
            return (_context.NguoiDungs?.Any(e => e.IdNguoiDung == id)).GetValueOrDefault();
        }
    }
}
