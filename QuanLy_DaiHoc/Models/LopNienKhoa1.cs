using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LopNienKhoa1
{
    public int Idlop { get; set; }

    public int? KhoaId { get; set; }

    public string? TenGv { get; set; }

    public DateTime? NamVao { get; set; }

    public DateTime? NamRa { get; set; }

    public int? NienKhoa { get; set; }

    public virtual Khoa? Khoa { get; set; }

    public virtual ICollection<LopSinhVienNienKhoa> LopSinhVienNienKhoas { get; set; } = new List<LopSinhVienNienKhoa>();
}
