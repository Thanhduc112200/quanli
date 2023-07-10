using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class Khoa
{
    public int KhoaId { get; set; }

    public string? TenKhoa { get; set; }

    public DateTime? NgayThanhLap { get; set; }

    public string? Mota { get; set; }

    public byte[]? Anhkhoa { get; set; }

    public string? Truongkhoa { get; set; }

    public string? Sodienthoai { get; set; }

    public string? Email { get; set; }

    public virtual ICollection<LopNienKhoa1> LopNienKhoa1s { get; set; } = new List<LopNienKhoa1>();
}
