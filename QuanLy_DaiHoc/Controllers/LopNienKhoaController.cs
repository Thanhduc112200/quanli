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
    [Route("api/[controller]")]
    [ApiController]
    public class LopNienKhoaController : ControllerBase
    {
        private readonly ILopNienKhoa _lopNienKhoa;

        public LopNienKhoaController(ILopNienKhoa lopNienKhoa)
        {
            _lopNienKhoa = lopNienKhoa;
        }
        // GET: LopTinChis
        [HttpGet]
        public ActionResult<List<LopNienKhoa1>> getAllLopNienKhoa()
        {
            return _lopNienKhoa.GetListLopNienKhoa();
        }
        // GET: LopTinChis/Details/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
            {
                return BadRequest("id khoong hop le!");
            }
            var lopNienKhoa = _lopNienKhoa.GetLopNienKhoa(id);
            if (lopNienKhoa == null)
            {
                return NotFound("khong tim thay lop theo Id");
            }
            return Ok(lopNienKhoa);
        }
        [HttpPost("Create")]
        public async Task<IActionResult> Create(LopNienKhoa1 lopNienKhoa)
        {
            if (validate(lopNienKhoa) == true)
            {
                int id =  _lopNienKhoa.CreateLopNienKhoa(lopNienKhoa);
                if (id == 0) return Conflict("lop hoc da ton tai");
                return Ok(id);
            }
            return BadRequest("du lieu khong hop le");
        }
        private bool validate(LopNienKhoa1 obj)
        {
            if (obj.Idlop < 0)
            {
                return false;
            }
            if (obj.TenGv.Length < 10)
            {
                return false;
            }
            DateTime namvao = DateTime.Today;
            if (obj.NamVao < DateTime.Today)
            {
                return false;
            }
            DateTime Namra = DateTime.Today;
            if (obj.NamRa > DateTime.Today)
            {
                return false;
            }
            if (obj.NienKhoa < 0)
            {
                return false;
            }
            if (obj.KhoaId < 0)
            {
                return false;
            }
            return true;
        }
        [HttpPut("edit/{id}")]
        public async Task<IActionResult> Edit(int id, LopNienKhoa1 lopNienKhoa)
        {
            if (id == 0)
            {
                return BadRequest("Id không hợp lệ!");
            }
            if (validate(lopNienKhoa) == true)
            {
                try
                {
                    int edit = _lopNienKhoa.EditLopNienKhoa(id, lopNienKhoa);
                    if (edit == 0)
                    {
                        return BadRequest("Lớp nien khoa không tồn tại!");
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    return BadRequest("");

                }
            }
            return BadRequest("Dữ liệu không hợp lệ!");
        }
        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (id == 0) return BadRequest("Id không hợp lệ!");
            if (_lopNienKhoa.context().LopNienKhoas == null)
            {
                return Problem("Entity set 'QuanLyDaiHocContext.LopTinChis'  is null.");
            }
            _lopNienKhoa.DeleteLopNienKhoa(id);
            return Ok();
        }

        private bool LopNienKhoaExists(int id)
        {
            return (_lopNienKhoa.context().LopNienKhoas?.Any(e => e.KhoaId == id)).GetValueOrDefault();
        }
    }
}
