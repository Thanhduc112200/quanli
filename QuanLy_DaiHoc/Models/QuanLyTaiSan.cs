using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class QuanLyTaiSan
{
    public int IdtaiSan { get; set; }

    public string? LoaiTaiSan { get; set; }

    public string? TenTaiSan { get; set; }

    public int? SoLuong { get; set; }

    public string? GiaTriTaiSan { get; set; }

    public DateTime? NgayNhap { get; set; }

    public int? IdnguoiNhap { get; set; }

    public string? GhiChu { get; set; }
}
