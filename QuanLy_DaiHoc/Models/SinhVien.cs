using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class SinhVien
{
    public int MaSinhVien { get; set; }

    public string? TenSinhVien { get; set; }

    public int? Tuoi { get; set; }

    public string? DiaChi { get; set; }

    public string? QueQuan { get; set; }

    public DateTime? SinhNgay { get; set; }

    public virtual ICollection<ThamGium> ThamGia { get; set; } = new List<ThamGium>();
}
