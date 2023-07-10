using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LopSinhVien
{
    public int IdLopSinhVien { get; set; }

    public int MaSinhVien { get; set; }

    public int IdLopTinChi { get; set; }

    public virtual LopTinChi IdLopTinChiNavigation { get; set; } = null!;

    public virtual NguoiDung MaSinhVienNavigation { get; set; } = null!;
}
