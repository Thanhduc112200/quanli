using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class DongTienRa
{
    public int IdnguoiRut { get; set; }

    public string? TenNgRut { get; set; }

    public int SoTienRut { get; set; }

    public string? LyDo { get; set; }

    public string KyDuyet { get; set; } = null!;
}
