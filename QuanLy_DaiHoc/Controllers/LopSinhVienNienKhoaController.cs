using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.BusinessLogic.Services;
using QuanLy_DaiHoc.Models;
using System.ComponentModel.Design;

namespace QuanLy_DaiHoc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LopSinhVienNienKhoaController : ControllerBase
    {
        private readonly QuanLyDaiHocContext _context;
        private readonly ILopSinhVienNienKhoa _LopSinhVienNienKhoaServices;
        public LopSinhVienNienKhoaController(QuanLyDaiHocContext context)
        {
            _context = context;
        }
        //get listLopSinhVienNienkHoa
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NguoiDung>>> GetLopSinhVienNenKhoa(int id)
        {
            return await _LopSinhVienNienKhoaServices.getListLopSinhVienNienKhoaById(id);
        }
        //add sinhvien
        [HttpPost]
        public async Task<ActionResult> AddSinhVien(int idSinhVien, int IdLop)
        {
            _LopSinhVienNienKhoaServices.AddSinhVien(IdLop, idSinhVien);
            return Ok();
        }
        //Delete sinhvien
        [HttpDelete]
        public async Task<ActionResult> DeleteSinhVien (int idSinhVien, int IdLop)
        {
            _LopSinhVienNienKhoaServices.DeleteSinhVien(IdLop, idSinhVien);
            return Ok();
        }
    } 
    
}
