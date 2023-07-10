using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class LopTinChiServices : ILopTinChi
    {
        private readonly QuanLyDaiHocContext _context;
        public LopTinChiServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public QuanLyDaiHocContext context()
        {
            return _context;
        }

        public void createLopTinChi(LopTinChi lopTinChi)
        {
            try
            {
                _context.LopTinChis.Add(lopTinChi);
                _context.SaveChanges();

            }
            catch
            {
             
            }       
        }

        public void deleteLopTinChiById(int? id)
        {
            var lopTinChi = getLopTinChiById(id);
            if (lopTinChi != null)
            {
                _context.LopTinChis.Remove(lopTinChi);
                _context.SaveChanges();
            }         
        }

        public void editLopTinChi(LopTinChi lopTinChi)
        {

            var lopTinChiEdit = getLopTinChiById(lopTinChi.IdLopTinChi);
            if (null != lopTinChiEdit)
            {
                lopTinChiEdit.Tenlop = lopTinChi.Tenlop;
                lopTinChiEdit.IdMonHoc = lopTinChi.IdMonHoc;
                lopTinChiEdit.NgayDay = lopTinChi.NgayDay;
                lopTinChiEdit.NgayKetThuc = lopTinChi.NgayKetThuc;
                _context.SaveChanges();
            }
        }

        public  List<LopTinChi> getListLopTinChi()
        {
           return _context.LopTinChis.Include(x=>x.IdMonHocNavigation).ToList();
        }

        public LopTinChi getLopTinChiById(int? id)
        {
            if (id < 0 || id == 0) return null;
            LopTinChi lopTinChi = _context.LopTinChis.Include(x=>x.IdMonHocNavigation).FirstOrDefault(x=>x.IdLopTinChi == id);
            return lopTinChi;
        }
    
    }
}
