using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class QuanLyPhong
{
    public int Idphong { get; set; }

    public string TenP { get; set; } = null!;

    public string? Sdt { get; set; }

    public string? Dcm { get; set; }
}
