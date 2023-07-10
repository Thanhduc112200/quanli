using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface ILopSinhVienNienKhoa
    {
       public Task<List<NguoiDung>> getListLopSinhVienNienKhoaById(int id);
       public Task<List<NguoiDung>> GetListLopSinhVienNienKhoaAdd(int id);
       public void AddSinhVien(int idLop, int idSinhVien);
       public void DeleteSinhVien(int idLop, int idSinhVien);
    }
}
