using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class NamHoc
{
    public int NamHocId { get; set; }

    public DateTime? BatDau { get; set; }

    public DateTime? KetThuc { get; set; }

    public virtual ICollection<HocPhi> HocPhis { get; set; } = new List<HocPhi>();

    public virtual ICollection<HocKi> HocKis { get; set; } = new List<HocKi>();
}
