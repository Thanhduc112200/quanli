using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;
using static Azure.Core.HttpHeader;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class LopNienKhoaServices : ILopNienKhoa
    {
        private readonly QuanLyDaiHocContext _context;
        public LopNienKhoaServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public QuanLyDaiHocContext context()
        {
            return _context;
        }

        public int CreateLopNienKhoa(LopNienKhoa1 lopNienKhoa)
        {
            try
            {
                _context.LopNienKhoa1s.Add(lopNienKhoa);
                _context.SaveChanges();
                return (lopNienKhoa.Idlop);

            }
            catch
            {
                return -1;
            }
        }
        public void DeleteLopNienKhoaById(int id)
        {
            var lopNienKhoa = _context.LopNienKhoas.Find(id);
            if (lopNienKhoa != null)
            {
                _context.LopNienKhoas.Remove(lopNienKhoa);
                _context.SaveChanges();
            }
        }       
        public void EditLopNienKhoa(int id ,LopNienKhoa1 lopNienKhoa)
        {
            var lopNienKhoaEdit = _context.LopNienKhoa1s.Find(lopNienKhoa.Idlop);
            if (null != lopNienKhoaEdit)
            {
                lopNienKhoaEdit.KhoaId = lopNienKhoa.KhoaId;
                lopNienKhoaEdit.TenGv = lopNienKhoa.TenGv;
                lopNienKhoaEdit.NamVao = lopNienKhoa.NamVao;
                lopNienKhoaEdit.NamRa = lopNienKhoa.NamRa;
                lopNienKhoaEdit.NienKhoa = lopNienKhoa.NienKhoa;
                _context.SaveChanges();
            }
        }


        public List<LopNienKhoa1> GetListLopNienKhoa()
        {
            return _context.LopNienKhoa1s.ToList();
        }
        public LopNienKhoa1 GetLopNienKhoa(int? id)
        {
            if (id < 0 || id == 0) return null;
            LopNienKhoa1 lopNienKhoa = _context.LopNienKhoa1s.Include(x => x.KhoaId).FirstOrDefault(x => x.Idlop == id);
            return lopNienKhoa;
        }

        int ILopNienKhoa.EditLopNienKhoa(int id, LopNienKhoa1 lopNienKhoa)
        {
            throw new NotImplementedException();
        }
        public void DeleteLopNienKhoa(int id)
        {
            var delete = _context.LopNienKhoas.Find(id);
            _context.LopNienKhoas.Remove(delete);
            _context.SaveChanges();
        }
    }
}
