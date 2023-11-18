using System;
using System.Collections.Generic;

namespace dadadanet.Models;

public partial class ConstructionMaterial
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Price { get; set; }

    public string? Quantity { get; set; }
}
