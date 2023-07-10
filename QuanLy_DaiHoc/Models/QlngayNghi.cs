using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class QlngayNghi
{
    public int Stt { get; set; }

    public string HoVaTen { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public int Sđt { get; set; }

    public DateTime NgayNghi { get; set; }

    public string ChucVu { get; set; } = null!;

    public string LyDo { get; set; } = null!;
}
