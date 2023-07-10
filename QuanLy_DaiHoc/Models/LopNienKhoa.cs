using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LopNienKhoa
{
    public int NienKhoaId { get; set; }

    public int IdLop { get; set; }

    public int KhoaId { get; set; }

    public string NienKhoa { get; set; } = null!;

    public string TenGv { get; set; } = null!;

    public string TenHs { get; set; } = null!;

    public string GioiTinh { get; set; } = null!;

    public DateTime NgaySinh { get; set; }

    public int SdtphuHuynh { get; set; }

    public string DiaChiNha { get; set; } = null!;

    public decimal HocPhi { get; set; }

    public string KqhocTap { get; set; } = null!;
}
