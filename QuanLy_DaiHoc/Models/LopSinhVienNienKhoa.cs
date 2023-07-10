using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LopSinhVienNienKhoa
{
    public int IdLopSinhVien { get; set; }

    public int? MaSinhVien { get; set; }

    public int? Idlop { get; set; }

    public virtual LopNienKhoa1? IdlopNavigation { get; set; }

    public virtual NguoiDung? MaSinhVienNavigation { get; set; }
}
