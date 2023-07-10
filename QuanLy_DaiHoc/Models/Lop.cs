using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class Lop
{
    public int IdLop { get; set; }

    public string? TenLop { get; set; }

    public virtual ICollection<SuDungPhong> SuDungPhongs { get; set; } = new List<SuDungPhong>();
}
