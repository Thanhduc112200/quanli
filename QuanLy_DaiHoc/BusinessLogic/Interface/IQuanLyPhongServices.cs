using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface IQuanLyPhongServices
    {
        public List<QuanLyPhong> GetQuanLyPhong();
        public QuanLyPhong GetQuanLyPhong(int ID);
    }
}
