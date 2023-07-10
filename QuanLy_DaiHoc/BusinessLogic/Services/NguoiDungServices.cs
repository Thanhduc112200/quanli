using QuanLy_DaiHoc.BusinessLogic.Interface;
using QuanLy_DaiHoc.BusinessModels;
using QuanLy_DaiHoc.Models;

namespace QuanLy_DaiHoc.BusinessLogic.Services
{
    public class NguoiDungServices : INguoiDungServices
    {
        //db = new db
        private readonly QuanLyDaiHocContext _context;
        private readonly IKhoaServices _khoaServices;
        private readonly ITblBanServices _TblBanServices;


        public NguoiDungServices(QuanLyDaiHocContext context, IKhoaServices khoaServices)
        {
            _context = context;
            _khoaServices = khoaServices;
        }

        public NguoiDung GetNguoiDungByKhoaID(int idKhoa)
        {
            throw new NotImplementedException();
        }

        public NguoiDung GetNguoiDungByTblBanID(int idTblBanID)
        {
            throw new NotImplementedException();
        }

        List<NguoiDung> INguoiDungServices.GetNguoiDung()
        { 
            return _context.NguoiDungs.ToList(); 
        }


        NguoiDungBusiness INguoiDungServices.GetNguoiDungByID(int id)
        {

            NguoiDungBusiness NguoiDungBusiness = new NguoiDungBusiness();

            NguoiDungBusiness.NguoiDung = _context.NguoiDungs.Where(n => n.IdNguoiDung == id).FirstOrDefault();
            
            NguoiDungBusiness.Khoa = _khoaServices.GetKhoa(1);
              
            //lop hoc, ... 

            return NguoiDungBusiness;
        }

        NguoiDung INguoiDungServices.GetNguoiDungByUserNamePassWord(int id)
        {
            return null;
        }
    }
}
