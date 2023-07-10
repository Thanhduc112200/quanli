using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;
using System.Linq;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class LopSinhVienNienKhoaServices : ILopSinhVienNienKhoa
    {
        private readonly QuanLyDaiHocContext _context;
        public LopSinhVienNienKhoaServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public void AddSinhVien(int idLop, int idSinhVien)
            {
                LopSinhVienNienKhoa itemAdd = new LopSinhVienNienKhoa();
                itemAdd.Idlop = idLop;
                itemAdd.MaSinhVien = idSinhVien;
                _context.LopSinhVienNienKhoas.Add(itemAdd);
                _context.SaveChanges(); 
            }
        public void DeleteSinhVien(int idLop, int idSinhVien)
        {
            var deleteSv = _context.LopSinhVienNienKhoas.FirstOrDefault(s => s.Idlop == idLop && s.MaSinhVien == idSinhVien);
            _context.LopSinhVienNienKhoas.Remove(deleteSv);
            _context.SaveChanges();
        }

        public async Task<List<NguoiDung>> GetListLopSinhVienNienKhoaAdd(int id)
        {
            var listSinhVien = await _context.LopSinhVienNienKhoas
                .Include(x => x.MaSinhVienNavigation).Where(x => x.Idlop != id)
                .Select(x => x.MaSinhVienNavigation)
                .ToListAsync();
            return listSinhVien;
        }

        public async Task<List<NguoiDung>> getListLopSinhVienNienKhoaById(int id)
        {
            var listSinhVien = await _context.LopSinhVienNienKhoas
                .Include(x => x.MaSinhVienNavigation).Where(x =>x.Idlop == id)
                .Select(x => x.MaSinhVienNavigation)
                .ToListAsync();
            return listSinhVien;
        }

    }
}
