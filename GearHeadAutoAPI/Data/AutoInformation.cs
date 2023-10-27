using System;
using System.Collections.Generic;

namespace GearHeadAutoAPI.Data;

public partial class AutoInformation
{
    public string AutoId { get; set; } = null!;

    public string? Condition { get; set; }

    public long? Year { get; set; }

    public string? Make { get; set; }

    public string? Model { get; set; }

    public string? Color { get; set; }

    public string? Type { get; set; }

    public long? Miles { get; set; }

    public long? Zip { get; set; }

    public decimal? Price { get; set; }

    public string? Image { get; set; }
}
