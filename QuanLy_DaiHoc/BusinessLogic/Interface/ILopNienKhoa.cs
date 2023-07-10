using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Interface
{
    public interface ILopNienKhoa
    {
        public List<LopNienKhoa1> GetListLopNienKhoa();
        public LopNienKhoa1 GetLopNienKhoa(int? id);
        public void DeleteLopNienKhoaById(int id);
        public int EditLopNienKhoa(int id, LopNienKhoa1 lopNienKhoa);
        public int CreateLopNienKhoa(LopNienKhoa1 lopNienKhoa);
        public QuanLyDaiHocContext context();

        void DeleteLopNienKhoa(int id);
    }   
}
