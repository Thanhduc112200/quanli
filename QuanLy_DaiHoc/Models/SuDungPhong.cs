using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class SuDungPhong
{
    public int IdSdp { get; set; }

    public DateTime? NgaySd { get; set; }

    public DateTime? NgayTra { get; set; }

    public int? IdLop { get; set; }

    public int? IdMonHoc { get; set; }

    public int? IdPhong { get; set; }

    public virtual Lop? IdLopNavigation { get; set; }

    public virtual MonHoc? IdMonHocNavigation { get; set; }

    public virtual PhongHoc? IdPhongNavigation { get; set; }
}
