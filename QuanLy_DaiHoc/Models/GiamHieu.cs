using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class GiamHieu
{
    public int GiamHieuId { get; set; }

    public byte[]? Anh { get; set; }

    public string? Ten { get; set; }

    public string? ChucVu { get; set; }

    public DateTime? NhiemKy { get; set; }

    public virtual ICollection<NguoiDung> NguoiDungs { get; set; } = new List<NguoiDung>();
}
