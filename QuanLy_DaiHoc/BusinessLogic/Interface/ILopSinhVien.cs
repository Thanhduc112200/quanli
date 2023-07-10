using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface ILopSinhVien
    {
        public List<NguoiDung> getListLopSinhVienById(int id);
        public List<NguoiDung> getListSinhVienAdd(int id);
        public void addSinhVien(int id, List<int> idSinhVien);
        public void removeSinhVien(int id , int idSinhVien);
        
    }
}
