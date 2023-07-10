using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class MonHoc
{
    public int IdMonHoc { get; set; }

    public string? TenMonHoc { get; set; }

    public int? SoTinChi { get; set; }

    public virtual ICollection<LopTinChi> LopTinChis { get; set; } = new List<LopTinChi>();

    public virtual ICollection<SuDungPhong> SuDungPhongs { get; set; } = new List<SuDungPhong>();
}
