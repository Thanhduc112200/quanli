using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class KhoaServices : KhoaBase, IKhoaServices
    {
        //db = new db
        private readonly QuanLyDaiHocContext _context;

        public KhoaServices(QuanLyDaiHocContext context)
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
            var khoaToReturn = _context.Khoas.FirstOrDefault(k => k.KhoaId == ID);
            return khoaToReturn;
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



    public class KhoaBase
    {
        //db = new db
        private readonly QuanLyDaiHocContext _context;

        //public KhoaBase(QuanLyDaiHocContext context)
        //{
        //    _context = context;
        //}

        public List<Khoa> GetKhoa888()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }

        public List<Khoa> GetKhoa1()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }
        public List<Khoa> GetKhoa2()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }


        public List<Khoa> GetKhoa3()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }

        public List<Khoa> GetKhoa4()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }

        public List<Khoa> GetKhoa5()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }

        public List<Khoa> GetKhoaNewest()
        {
            return _context.Khoas.ToList();
            //1000 dong code 
        }
    }

}
