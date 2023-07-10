using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class ThongTinNguoiDung
{
    public int IdTtuser { get; set; }

    public int IdNguoiDung { get; set; }

    public string? FirstName { get; set; }

    public string? MiddleName { get; set; }

    public string? LastName { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public string? PrivateEmail { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public bool? IsStudent { get; set; }

    public bool? IsTeacher { get; set; }

    public bool? IsBgh { get; set; }

    public virtual NguoiDung IdNguoiDungNavigation { get; set; } = null!;
}
