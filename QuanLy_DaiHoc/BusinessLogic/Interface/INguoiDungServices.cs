using QuanLy_DaiHoc.BusinessModels;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface INguoiDungServices
    {
        /// <summary>
        /// tra ve danh sach khoa
        /// </summary>
        /// <returns></returns>
        public List<NguoiDung> GetNguoiDung();

        /// <summary>
        /// tra ve 1 nguoi dung theo dieu kien loc
        /// </summary>
        /// <returns></returns>
        public NguoiDungBusiness GetNguoiDungByID(int id);
        public NguoiDung GetNguoiDungByUserNamePassWord(int id);
        public NguoiDung GetNguoiDungByKhoaID(int idKhoa);
        public NguoiDung GetNguoiDungByTblBanID(int idTblBanID);
    }
}
