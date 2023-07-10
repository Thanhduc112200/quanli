using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LopTinChi
{
    public int IdLopTinChi { get; set; }

    public int? IdMonHoc { get; set; }

    public DateTime? NgayDay { get; set; }

    public DateTime? NgayKetThuc { get; set; }

    public string? Tenlop { get; set; }

    public virtual MonHoc? IdMonHocNavigation { get; set; }

    public virtual ICollection<LopSinhVien> LopSinhViens { get; set; } = new List<LopSinhVien>();
}
