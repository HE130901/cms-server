using System;
using System.Collections.Generic;

namespace cms_server.Models;

public partial class ServiceOrder
{
    public int ServiceOrderId { get; set; }

    public int CustomerId { get; set; }

    public int NicheId { get; set; }

    public int ServiceId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string Status { get; set; } = null!;

    public string? CompletionImage { get; set; }

    public int StaffId { get; set; }

    public virtual Customer Customer { get; set; } = null!;

    public virtual Niche Niche { get; set; } = null!;

    public virtual Service Service { get; set; } = null!;

    public virtual Staff Staff { get; set; } = null!;
}
