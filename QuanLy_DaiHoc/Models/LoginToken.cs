using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class LoginToken
{
    public int? IdNguoiDung { get; set; }

    public string TokenGuid { get; set; } = null!;

    public virtual NguoiDung? IdNguoiDungNavigation { get; set; }
}
