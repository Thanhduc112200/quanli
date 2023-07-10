using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class ToaNha
{
    public int IdToaNha { get; set; }

    public string? TenToaNha { get; set; }

    public virtual ICollection<PhongHoc> PhongHocs { get; set; } = new List<PhongHoc>();
}
