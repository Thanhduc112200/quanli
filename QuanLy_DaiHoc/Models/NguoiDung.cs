using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class NguoiDung
{
    public int IdNguoiDung { get; set; }

    public string? TenNguoiDung { get; set; }

    public string? Salt { get; set; }

    public string? Md5Password { get; set; }

    public string? Password { get; set; }

    public string? FieldA { get; set; }

    public int? GiamHieuId { get; set; }

    public virtual GiamHieu? GiamHieu { get; set; }

    public virtual ICollection<LoginToken> LoginTokens { get; set; } = new List<LoginToken>();

    public virtual ICollection<LopSinhVienNienKhoa> LopSinhVienNienKhoas { get; set; } = new List<LopSinhVienNienKhoa>();

    public virtual ICollection<LopSinhVien> LopSinhViens { get; set; } = new List<LopSinhVien>();

    public virtual ICollection<ThongTinNguoiDung> ThongTinNguoiDungs { get; set; } = new List<ThongTinNguoiDung>();
}
