using System;
using System.Collections.Generic;

namespace QuanLy_DaiHoc.Models;

public partial class ChatGpt
{
    public int MesseageId { get; set; }

    public string? Question { get; set; }

    public string? Answer { get; set; }

    public DateTime? TimeRequest { get; set; }

    public string? RawAnswer { get; set; }

    public string? ChatId { get; set; }

    public string? UserName { get; set; }
}
