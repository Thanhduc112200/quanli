using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessModels
{
    public class NguoiDungBusiness
    {
        public Khoa? Khoa { get; set; }
        public NguoiDung? NguoiDung { get; set; } 
        public TblBan? TblBan { get; set; } 
        public QuanLyPhong? QuanLyPhong { get; set; } 
    }
}
