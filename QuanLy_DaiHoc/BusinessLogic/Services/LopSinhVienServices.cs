using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class LopSinhVienServices : ILopSinhVien
    {
        private readonly QuanLyDaiHocContext _context;
        public LopSinhVienServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public void addSinhVien(int id, List<int> idSinhVien)
        {
            foreach(var item in idSinhVien)
            {
                LopSinhVien itemAdd = new LopSinhVien();
                itemAdd.IdLopTinChi = id;
                itemAdd.MaSinhVien = item;
                _context.LopSinhViens.Add(itemAdd);
                _context.SaveChanges();
            }
            
        }

        public List<NguoiDung> getListLopSinhVienById(int id)
        {
            var listSinhVien = _context.LopSinhViens.Include(x=>x.MaSinhVienNavigation).Where(x => x.IdLopTinChi == id).Select(x => x.MaSinhVienNavigation).ToList();
            return listSinhVien;
        }
        public List<NguoiDung> getListSinhVienAdd(int id)
        {
            var listSinhVien = _context.NguoiDungs
                .Where(sinhVien => !_context.LopSinhViens
                    .Any(lopSinhVien => lopSinhVien.MaSinhVien == sinhVien.IdNguoiDung && lopSinhVien.IdLopSinhVien == id))
                .ToList();
            return listSinhVien;
        }

        public void removeSinhVien(int id, int idSinhVien)
        {
            LopSinhVien itemAdd = _context.LopSinhViens.FirstOrDefault(x=>x.IdLopTinChi== id&&x.MaSinhVien== idSinhVien);
            _context.LopSinhViens.Remove(itemAdd);
            _context.SaveChanges();
        }
    }
}
