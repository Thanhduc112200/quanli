using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class KhoaServicesUpgrade : KhoaBase, IKhoaServices
    {
        //db = new db
        private readonly QuanLyDaiHocContext _context;

        public KhoaServicesUpgrade(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public List<Khoa> GetKhoa()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }

        public Khoa GetKhoa(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa15(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa2(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa22(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa23(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa33(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa6(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa66(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa7(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa78(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa9(int ID)
        {
            throw new NotImplementedException();
        }

        public Khoa GetKhoa98(int ID)
        {
            throw new NotImplementedException();
        }
    } 

}
