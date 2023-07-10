using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface ITblBanServices
    {
        public List<TblBan> GetTblBans();
        public TblBan GetTblBans(int ID);
    }
}
