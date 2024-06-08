﻿using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class Floor
{
    public int FloorId { get; set; }

    public int BuildingId { get; set; }

    public string? FloorDescription { get; set; }

    public string? FloorName { get; set; }

    public decimal NichePrice { get; set; }

    public virtual ICollection<Area> Areas { get; set; } = new List<Area>();

    public virtual Building Building { get; set; } = null!;
}
