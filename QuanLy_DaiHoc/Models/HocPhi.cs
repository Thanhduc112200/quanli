using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class HocPhi
{
    public int HocPhiId { get; set; }

    public string? TenHocPhi { get; set; }

    public DateTime? NgayNop { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public int? KhoiNganhId { get; set; }

    public int? NamHocId { get; set; }

    public int? HocKiId { get; set; }

    public virtual HocKi? HocKi { get; set; }

    public virtual KhoiNganh? KhoiNganh { get; set; }

    public virtual NamHoc? NamHoc { get; set; }
}
