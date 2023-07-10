using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class KhoiNganh
{
    public int KhoiNganhId { get; set; }

    public string TenKhoiNganh { get; set; } = null!;

    public string? Mota { get; set; }

    public virtual ICollection<HocPhi> HocPhis { get; set; } = new List<HocPhi>();
}
