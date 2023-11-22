using System;
using System.Collections.Generic;

namespace gavmeaw.Models;

public partial class ConstructionMaterial
{
    public int id { get; set; }

    public string? name { get; set; }

    public string? price { get; set; }

    public string? quantity { get; set; }
}
