using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class QuanLyPhongServices : QuanLyPhongBase, IQuanLyPhongServices
    {
        private readonly QuanLyDaiHocContext _context;

        public QuanLyPhongServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public List<QuanLyPhong> GetQuanLyPhong()
        {
            return _context.QuanLyPhongs.ToList();
            //1000 dong code 
        }

        public QuanLyPhong GetQuanLyPhong(int ID)
        {
            var qlpToReturn = _context.QuanLyPhongs.FirstOrDefault(k => k.Idphong == ID);
            return qlpToReturn;
        }

    }

    public class QuanLyPhongBase
    {
        private readonly QuanLyDaiHocContext _context;
        public List<QuanLyPhong> GetQuanLyPhong()
        {
            return _context.QuanLyPhongs.ToList();
        }
    }
}
