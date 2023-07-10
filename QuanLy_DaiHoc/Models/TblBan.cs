using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class TblBan
{
    public int MaBan { get; set; }

    public string? TenBan { get; set; }

    public string? TruongBan { get; set; }

    public DateTime? NgayThanhLap { get; set; }

    public string? Sdt { get; set; }

    public string? Email { get; set; }
}
