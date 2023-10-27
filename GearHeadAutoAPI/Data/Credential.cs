using System;
using System.Collections.Generic;

namespace GearHeadAutoAPI.Data;

public partial class Credential
{
    public string Username { get; set; } = null!;

    public string? Password { get; set; }
}
