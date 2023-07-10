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
    public class LopTinChisController : Controller
    {
        private readonly ILopTinChi _lopTinChi;
        private readonly ILopSinhVien _lopSinhVien;
        public LopTinChisController( ILopTinChi lopTinChi, ILopSinhVien lopSinhVien)
        {
            _lopTinChi = lopTinChi;
            _lopSinhVien = lopSinhVien;
        }

        // GET: LopTinChis
        public async Task<IActionResult> Index()
        {      
            return View( _lopTinChi.getListLopTinChi());
        }

        // GET: LopTinChis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _lopTinChi.context().LopTinChis == null)
            {
                return NotFound();
            }

            var lopTinChi = _lopTinChi.getLopTinChiById(id);
            if (lopTinChi == null)
            {
                return NotFound();
            }

            return View(lopTinChi);
        }

        // GET: LopTinChis/Create
        public IActionResult Create()
        {
            ViewData["IdMonHoc"] = new SelectList(_lopTinChi.context().MonHocs, "IdMonHoc", "TenMonHoc");
            return View();
        }

        // POST: LopTinChis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdLopTinChi,IdMonHoc,NgayDay,NgayKetThuc,Tenlop")] LopTinChi lopTinChi)
        {
            if (ModelState.IsValid)
            {
                _lopTinChi.createLopTinChi(lopTinChi);
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdMonHoc"] = new SelectList(_lopTinChi.context().MonHocs, "IdMonHoc", "TenMonHoc", lopTinChi.IdMonHoc);
            return View(lopTinChi);
        }

        // GET: LopTinChis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _lopTinChi.context().LopTinChis == null)
            {
                return NotFound();
            }

            var lopTinChi = _lopTinChi.getLopTinChiById(id);
            if (lopTinChi == null)
            {
                return NotFound();
            }
            ViewData["IdMonHoc"] = new SelectList(_lopTinChi.context().MonHocs, "IdMonHoc", "TenMonHoc", lopTinChi.IdMonHoc);
            return View(lopTinChi);
        }

        // POST: LopTinChis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdLopTinChi,IdMonHoc,NgayDay,NgayKetThuc,Tenlop")] LopTinChi lopTinChi)
        {
            if (id != lopTinChi.IdLopTinChi)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   _lopTinChi.editLopTinChi(lopTinChi);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LopTinChiExists(lopTinChi.IdLopTinChi))
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
            ViewData["IdMonHoc"] = new SelectList(_lopTinChi.context().MonHocs, "IdMonHoc", "TenMonHoc", lopTinChi.IdMonHoc);
            return View(lopTinChi);
        }

        // GET: LopTinChis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _lopTinChi.context().LopTinChis == null)
            {
                return NotFound();
            }

            var lopTinChi = _lopTinChi.getLopTinChiById(id);
            if (lopTinChi == null)
            {
                return NotFound();
            }

            return View(lopTinChi);
        }

        // POST: LopTinChis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_lopTinChi.context().LopTinChis == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.LopTinChis'  is null.");
            }
            _lopTinChi.deleteLopTinChiById(id);                 
            return RedirectToAction(nameof(Index));
        }

        private bool LopTinChiExists(int id)
        {
          return (_lopTinChi.context().LopTinChis?.Any(e => e.IdLopTinChi == id)).GetValueOrDefault();
        }

        public async Task<IActionResult> LopSinhVien(int id)
        {
            ViewBag.Id = id;
            ViewBag.ListAddUser = _lopSinhVien.getListSinhVienAdd(id);
            return View(_lopSinhVien.getListLopSinhVienById(id));
        }
        [HttpPost]
        public IActionResult AddSinhVien(int id)
        {
            string[] selectedValues = Request.Form["mySelect"];
            List<int> selectedInts = new List<int>();
            foreach (string value in selectedValues)
            {
                int intValue;
                if (int.TryParse(value, out intValue))
                {
                    selectedInts.Add(intValue);
                }
            }
            _lopSinhVien.addSinhVien(id, selectedInts);
            return RedirectToAction("LopSinhVien", new { id = id });
        }
        public IActionResult deleteSinhVien(int id,int idUser)
        {        
            _lopSinhVien.removeSinhVien(id, idUser);
            return RedirectToAction("LopSinhVien", new { id = id });
        }
    }
}
