using System;
using System.Collections.Generic;

namespace GreatBritain.Models;

public partial class AttachedProduct
{
    public int MainProductId { get; set; }

    public int AttachedProductId { get; set; }

    public virtual Product MainProduct { get; set; } = null!;
}
