using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class HocKi
{
    public int HocKiId { get; set; }

    public string? TenHocKi { get; set; }

    public virtual ICollection<HocPhi> HocPhis { get; set; } = new List<HocPhi>();

    public virtual ICollection<NamHoc> NamHocs { get; set; } = new List<NamHoc>();
}
