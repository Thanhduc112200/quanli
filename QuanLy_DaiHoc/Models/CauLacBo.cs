using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class CauLacBo
{
    public int MaCauLacBo { get; set; }

    public string? TenCauLacBo { get; set; }

    public DateTime? NgayThanhLap { get; set; }

    public virtual ICollection<ThamGium> ThamGia { get; set; } = new List<ThamGium>();
}
