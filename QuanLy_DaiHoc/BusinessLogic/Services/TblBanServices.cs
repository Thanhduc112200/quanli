using Microsoft.EntityFrameworkCore;
using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class TblBanServices : ITblBanServices
    {
        private readonly QuanLyDaiHocContext _context;
        public TblBanServices(QuanLyDaiHocContext context)
        {
            _context = context;
        }

        public List<TblBan> GetTblBans()
        {
            return _context.TblBans.ToList();
        }

        public TblBan GetTblBans(int ID)
        {
            var quanlyban = _context.TblBans.FirstOrDefault(x => x.MaBan == ID);
            return quanlyban;
        }
    }
}
