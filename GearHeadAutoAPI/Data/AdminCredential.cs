using System;
using System.Collections.Generic;

namespace GearHeadAutoAPI.Data;

public partial class AdminCredential
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }

    public string? AdminPassword { get; set; }
}
