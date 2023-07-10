using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class PhongHoc
{
    public int IdPhong { get; set; }

    public string? TenPhong { get; set; }

    public bool? TrangThai { get; set; }

    public int? IdToaNha { get; set; }

    public virtual ToaNha? IdToaNhaNavigation { get; set; }

    public virtual ICollection<SuDungPhong> SuDungPhongs { get; set; } = new List<SuDungPhong>();
}
