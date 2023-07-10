using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class Loptinchi2
{
    public int LopTinChiId { get; set; }

    public string Tenloptinchi { get; set; } = null!;

    public int Sotin { get; set; }

    public string GiaoVien { get; set; } = null!;

    public DateTime NgayBatDau { get; set; }

    public DateTime NgayKetThuc { get; set; }
}
