using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface ILopTinChi
    {
        public List<LopTinChi> getListLopTinChi();
        public LopTinChi getLopTinChiById(int? id);
        public void deleteLopTinChiById(int? id);
        public void editLopTinChi(LopTinChi lopTinChi);
        public void createLopTinChi(LopTinChi lopTinChi);
        public QuanLyDaiHocContext context();
        
    }
}
