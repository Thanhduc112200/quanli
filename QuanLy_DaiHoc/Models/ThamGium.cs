using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class ThamGium
{
    public int MaSinhVien { get; set; }

    public int MaCauLacBo { get; set; }

    public DateTime? NgayThamGia { get; set; }

    public virtual CauLacBo MaCauLacBoNavigation { get; set; } = null!;

    public virtual SinhVien MaSinhVienNavigation { get; set; } = null!;
}
